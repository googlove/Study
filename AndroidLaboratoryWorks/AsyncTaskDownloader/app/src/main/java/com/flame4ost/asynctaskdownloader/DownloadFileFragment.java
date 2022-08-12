package com.flame4ost.asynctaskdownloader;

import android.content.Context;
import android.os.Bundle;
import android.support.annotation.Nullable;
import android.support.v4.app.Fragment;
import android.support.v4.app.FragmentManager;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ImageButton;
import android.widget.ListView;
import android.widget.ProgressBar;
import android.widget.TextView;
import android.widget.Toast;

import java.util.ArrayList;

public class DownloadFileFragment extends Fragment implements View.OnClickListener {
    public static final String FRAGMENT_TAG = "DownloadFileFragment";

    private RetainedFileDownloaderFragment retainedFileDownloaderFragment;
    private FragmentManager fragmentManager;

    private OnFragmentInteractionListener mListener;

    private ImageButton imageButtonFileDownloadingCancel, imageButtonFileDownloadingPause, imageButtonFileDownloadingResume;
    private TextView textViewCurrentFileName, textViewTimeCountdown;
    private ProgressBar progressBarDownloadingIndicator;

    private String currentFileName;

    public DownloadFileFragment() {

    }

    public static DownloadFileFragment newInstance() {
        DownloadFileFragment fragment = new DownloadFileFragment();

        return fragment;
    }

    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {
        View view = inflater.inflate(R.layout.fragment_download_file, container, false);

        imageButtonFileDownloadingCancel = (ImageButton) view.findViewById(R.id.imageButtonFileDownloadingCancel);
        imageButtonFileDownloadingPause = (ImageButton) view.findViewById(R.id.imageButtonFileDownloadingPause);
        imageButtonFileDownloadingResume = (ImageButton) view.findViewById(R.id.imageButtonFileDownloadingResume);
        textViewCurrentFileName = (TextView) view.findViewById(R.id.textViewCurrentFileName);
        textViewTimeCountdown = (TextView) view.findViewById(R.id.textViewTimeCountdown);
        progressBarDownloadingIndicator = (ProgressBar) view.findViewById(R.id.progressBarDownloadingIndicator);

        imageButtonFileDownloadingCancel.setOnClickListener(this);
        imageButtonFileDownloadingPause.setOnClickListener(this);
        imageButtonFileDownloadingResume.setOnClickListener(this);

        return view;
    }

    @Override
    public void onAttach(Context context) {
        super.onAttach(context);
        if (context instanceof OnFragmentInteractionListener) {
            mListener = (OnFragmentInteractionListener) context;
            fragmentManager = ((MainActivity) context).getSupportFragmentManager();
        } else {
            throw new RuntimeException(context.toString() + " must implement OnFragmentInteractionListener");
        }
    }

    @Override
    public void onDetach() {
        super.onDetach();
        mListener = null;
    }

    @Override
    public void onSaveInstanceState(Bundle outState) {
        outState.putString("currentFileName", currentFileName);
    }

    @Override
    public void onStart() {
        super.onStart();

        retainedFileDownloaderFragment = (RetainedFileDownloaderFragment) fragmentManager.findFragmentByTag(RetainedFileDownloaderFragment.FRAGMENT_TAG);
        retainedFileDownloaderFragment.link(textViewTimeCountdown, progressBarDownloadingIndicator);
    }

    @Override
    public void onActivityCreated(@Nullable Bundle savedInstanceState) {
        super.onActivityCreated(savedInstanceState);

        if (savedInstanceState != null) {
            currentFileName = savedInstanceState.getString("currentFileName");
            textViewCurrentFileName.setText(currentFileName);
        }
    }

    @Override
    public void onDestroy() {
        super.onDestroy();
    }

    @Override
    public void onClick(View v) {
        switch (v.getId()) {
            case R.id.imageButtonFileDownloadingCancel:
                mListener.callbackTaskEvent(RetainedFileDownloaderFragment.FILE_DOWNLOADING_CANCEL);

                break;
            case R.id.imageButtonFileDownloadingPause:
                mListener.callbackTaskEvent(RetainedFileDownloaderFragment.FILE_DOWNLOADING_PAUSE);

                break;
            case R.id.imageButtonFileDownloadingResume:
                mListener.callbackTaskEvent(RetainedFileDownloaderFragment.FILE_DOWNLOADING_RESUME);

                break;
        }
    }

    public void eventFileDownload(FileListItem fileListItem) {
        retainedFileDownloaderFragment.addToFileQueue(fileListItem);
    }

    public void changeCurrentFileName(String currentFileName) {
        this.currentFileName = currentFileName;
        textViewCurrentFileName.setText(this.currentFileName);
    }

    public interface OnFragmentInteractionListener {
        void callbackTaskEvent(int event);
    }
}
