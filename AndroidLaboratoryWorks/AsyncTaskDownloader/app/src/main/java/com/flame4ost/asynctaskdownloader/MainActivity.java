package com.flame4ost.asynctaskdownloader;

import android.support.v4.app.FragmentManager;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;

public class MainActivity extends AppCompatActivity implements FileListFragment.OnFragmentInteractionListener, DownloadFileFragment.OnFragmentInteractionListener, RetainedFileDownloaderFragment.OnFragmentInteractionListener {
    FileListFragment fileListFragment;
    DownloadFileFragment downloadFileFragment;
    RetainedListDataFragment retainedListDataFragment;
    RetainedFileDownloaderFragment retainedFileDownloaderFragment;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        FragmentManager fragmentManager = getSupportFragmentManager();

        fileListFragment = (FileListFragment) fragmentManager.findFragmentByTag(FileListFragment.FRAGMENT_TAG);
        downloadFileFragment = (DownloadFileFragment) fragmentManager.findFragmentByTag(DownloadFileFragment.FRAGMENT_TAG);
        retainedListDataFragment = (RetainedListDataFragment) fragmentManager.findFragmentByTag(RetainedListDataFragment.FRAGMENT_TAG);
        retainedFileDownloaderFragment = (RetainedFileDownloaderFragment) fragmentManager.findFragmentByTag(RetainedFileDownloaderFragment.FRAGMENT_TAG);

        if (fileListFragment == null) {
            fileListFragment  = FileListFragment.newInstance(true);
            fragmentManager.beginTransaction().add(R.id.fragmentFileList, fileListFragment, FileListFragment.FRAGMENT_TAG).commit();
        }

        if (downloadFileFragment == null) {
            downloadFileFragment = DownloadFileFragment.newInstance();
            fragmentManager.beginTransaction().add(R.id.fragmentDownloadProgress, downloadFileFragment, DownloadFileFragment.FRAGMENT_TAG).commit();
        }

        if (retainedListDataFragment == null) {
            retainedListDataFragment = new RetainedListDataFragment();
            fragmentManager.beginTransaction().add(retainedListDataFragment, RetainedListDataFragment.FRAGMENT_TAG).commit();
        }

        if (retainedFileDownloaderFragment == null) {
            retainedFileDownloaderFragment = new RetainedFileDownloaderFragment();
            fragmentManager.beginTransaction().add(retainedFileDownloaderFragment, RetainedFileDownloaderFragment.FRAGMENT_TAG).commit();
        }
    }

    @Override
    public void callbackEventFileDownload(FileListItem fileListItem) {
        downloadFileFragment.eventFileDownload(fileListItem);
    }

    @Override
    public void callbackTaskState(int state, FileListItem fileListItem) {
        fileListFragment.taskState(state, fileListItem);
    }

    @Override
    public void callbackChangeCurrentFileName(final String currentFileName) {
        runOnUiThread(new Runnable() {
            @Override
            public void run() {
                downloadFileFragment.changeCurrentFileName(currentFileName);
            }
        });
    }

    @Override
    public void callbackTaskEvent(int event) {
        retainedFileDownloaderFragment.taskEvent(event);
    }
}
