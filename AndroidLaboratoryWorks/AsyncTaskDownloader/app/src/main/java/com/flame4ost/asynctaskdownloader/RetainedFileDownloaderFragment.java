package com.flame4ost.asynctaskdownloader;

import android.content.Context;
import android.os.AsyncTask;
import android.os.Build;
import android.os.Bundle;
import android.support.annotation.Nullable;
import android.support.v4.app.Fragment;
import android.util.ArrayMap;
import android.util.Log;
import android.view.View;
import android.widget.ProgressBar;
import android.widget.TextView;

import java.lang.ref.WeakReference;
import java.util.ArrayList;

public class RetainedFileDownloaderFragment extends Fragment {
    public static final String FRAGMENT_TAG = "RetainedFileDownloaderFragment";

    public static final int TASK_START_DOWNLOADING = 0;
    public static final int TASK_COMPLETE_DOWNLOADING = 1;
    public static final int TASK_CANCEL_DOWNLOADING = 2;

    public static final int FILE_DOWNLOADING_CANCEL = 0;
    public static final int FILE_DOWNLOADING_PAUSE = 1;
    public static final int FILE_DOWNLOADING_RESUME = 2;

    private OnFragmentInteractionListener mListener;

    WeakReference<TextView> timeCountdownWeakReference;
    WeakReference<ProgressBar> downloadingIndicatorWeakReference;

    private boolean pause = false;
    private Object lockDownload = new Object();
    AsyncTaskFileDownloader currentTask;

    public RetainedFileDownloaderFragment() {

    }

    @Override
    public void onCreate(@Nullable Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);

        setRetainInstance(true);
    }

    @Override
    public void onAttach(Context context) {
        super.onAttach(context);
        if (context instanceof OnFragmentInteractionListener) {
            mListener = (OnFragmentInteractionListener) context;
        } else {
            throw new RuntimeException(context.toString() + " must implement OnFragmentInteractionListener");
        }
    }

    @Override
    public void onDetach() {
        super.onDetach();
        mListener = null;
    }

    private void currentTask(AsyncTaskFileDownloader asyncTaskFileDownloader) {
        currentTask = asyncTaskFileDownloader;
    }

    public void link(View... views) {
        timeCountdownWeakReference= new WeakReference<TextView>((TextView) views[0]);
        downloadingIndicatorWeakReference = new WeakReference<ProgressBar>((ProgressBar) views[1]);
    }

    public void addToFileQueue(FileListItem fileListItem) {
        new AsyncTaskFileDownloader(fileListItem).execute(fileListItem.getTimeDownload());
        mListener.callbackTaskState(TASK_START_DOWNLOADING, fileListItem);
    }

    public void taskEvent(int event) {
        switch (event) {
            case RetainedFileDownloaderFragment.FILE_DOWNLOADING_CANCEL:
                synchronized (lockDownload) {
                    lockDownload.notify();
                }

                currentTask.cancel(false);

                break;
            case RetainedFileDownloaderFragment.FILE_DOWNLOADING_PAUSE:
                pause = true;

                break;
            case RetainedFileDownloaderFragment.FILE_DOWNLOADING_RESUME:
                synchronized (lockDownload) {
                    lockDownload.notify();
                }

                break;
        }
    }

    public interface OnFragmentInteractionListener {
        void callbackTaskState(int state, FileListItem fileListItem);
        void callbackChangeCurrentFileName(String currentFileName);
    }

    private class AsyncTaskFileDownloader extends AsyncTask<Integer, Integer, Void> {
        private String fileName;
        private int timeDownload;
        private FileListItem fileListItem;

        public AsyncTaskFileDownloader(FileListItem fileListItem) {
            this.fileListItem = fileListItem;
            fileName = this.fileListItem.getFileName();
        }

        @Override
        protected Void doInBackground(Integer... integers) {
            timeDownload = integers[0];
            int currentProgress, remainingTime;

            currentTask(this);
            mListener.callbackChangeCurrentFileName(fileName);

            for (int i = 0; i < timeDownload; i++) {
                for (int y = 0; y < 10; y++) {
                    if (!isCancelled()) {
                        currentProgress = ((i * 10 + y + 1) * 100) / (timeDownload * 10);
                        remainingTime = timeDownload - i;

                        publishProgress(currentProgress, remainingTime);

                        try {
                            Thread.sleep(100);
                        } catch (InterruptedException e) {
                            e.printStackTrace();
                        }

                        if (pause) {
                            synchronized (lockDownload) {
                                try {
                                    lockDownload.wait();
                                } catch (InterruptedException e) {
                                    e.printStackTrace();
                                }
                            }

                            pause = false;
                        }
                    }
                }
            }

            return null;
        }

        @Override
        protected void onProgressUpdate(Integer... values) {
            super.onProgressUpdate(values);

            if (downloadingIndicatorWeakReference != null) {
                if (Build.VERSION.SDK_INT >= 24) {
                    ((ProgressBar) downloadingIndicatorWeakReference.get()).setProgress(values[0], true);
                } else {
                    ((ProgressBar) downloadingIndicatorWeakReference.get()).setProgress(values[0]);
                }
            }

            if (timeCountdownWeakReference != null) {
                ((TextView) timeCountdownWeakReference.get()).setText(Integer.toString(values[1]));
            }
        }

        @Override
        protected void onPostExecute(Void aVoid) {
            mListener.callbackChangeCurrentFileName("----------");
            mListener.callbackTaskState(TASK_COMPLETE_DOWNLOADING, fileListItem);

            if (downloadingIndicatorWeakReference != null) {
                if (Build.VERSION.SDK_INT >= 24) {
                    ((ProgressBar) downloadingIndicatorWeakReference.get()).setProgress(0, true);
                } else {
                    ((ProgressBar) downloadingIndicatorWeakReference.get()).setProgress(0);
                }
            }

            if (timeCountdownWeakReference != null) {
                ((TextView) timeCountdownWeakReference.get()).setText("000");
            }
        }

        @Override
        protected void onCancelled() {
            super.onCancelled();

            mListener.callbackChangeCurrentFileName("----------");
            mListener.callbackTaskState(TASK_CANCEL_DOWNLOADING, fileListItem);

            if (downloadingIndicatorWeakReference != null) {
                if (Build.VERSION.SDK_INT >= 24) {
                    ((ProgressBar) downloadingIndicatorWeakReference.get()).setProgress(0, true);
                } else {
                    ((ProgressBar) downloadingIndicatorWeakReference.get()).setProgress(0);
                }
            }

            if (timeCountdownWeakReference != null) {
                ((TextView) timeCountdownWeakReference.get()).setText("000");
            }
        }
    }
}
