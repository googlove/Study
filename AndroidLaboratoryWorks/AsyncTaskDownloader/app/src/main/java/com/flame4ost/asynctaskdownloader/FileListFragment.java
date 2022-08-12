package com.flame4ost.asynctaskdownloader;

import android.app.Activity;
import android.content.Context;
import android.content.Intent;
import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.support.v4.app.FragmentManager;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ImageButton;
import android.widget.ListView;
import android.widget.Toast;

import java.util.ArrayList;
import java.util.Random;

public class FileListFragment extends Fragment implements View.OnClickListener, FileListAdapter.OnAdapterInteractionListener {
    public static final String FRAGMENT_TAG = "FileListFragment";

    private RetainedListDataFragment retainedListDataFragment;
    private FragmentManager fragmentManager;

    private static final String ARG_PARAM1 = "loadArrayFiles";
    private boolean loadArrayFiles = false;

    private OnFragmentInteractionListener mListener;

    private ArrayList<FileListItem> listData = new ArrayList<FileListItem>();
    private FileListAdapter fileListAdapter;
    private ListView fileListView;
    private ImageButton imageButtonAddFile;

    private static final int DIALOG_ADD_FILE = 0;

    public static final int FILE_NOT_DOWNLOADED = 0;
    public static final int FILE_DOWNLOADING = 1;
    public static final int FILE_DOWNLOADED = 2;

    public FileListFragment() {

    }

    public static FileListFragment newInstance(boolean param1) {
        FileListFragment fragment = new FileListFragment();
        Bundle args = new Bundle();
        args.putBoolean(ARG_PARAM1, param1);
        fragment.setArguments(args);
        return fragment;
    }

    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);

        if (savedInstanceState == null) {
            if (getArguments() != null) {
                loadArrayFiles = getArguments().getBoolean(ARG_PARAM1);
            }
        }
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {
        View view = inflater.inflate(R.layout.fragment_file_list, container, false);

        fileListView = view.findViewById(R.id.fileListView);
        imageButtonAddFile = view.findViewById(R.id.imageButtonAddFile);

        imageButtonAddFile.setOnClickListener(this);

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

    private ArrayList<FileListItem> getListData() {
        ArrayList<FileListItem> listData = new ArrayList<FileListItem>();
        String[] names = getResources().getStringArray(R.array.name);

        for (int i = 0; i < names.length; i++) {
            listData.add(getListItem(names[i], new Random().nextInt(11) + 20, FileListFragment.FILE_NOT_DOWNLOADED));
        }

        return listData;
    }

    @Override
    public void onStart() {
        super.onStart();

        retainedListDataFragment = (RetainedListDataFragment) fragmentManager.findFragmentByTag(RetainedListDataFragment.FRAGMENT_TAG);

        listData = retainedListDataFragment.getFileListItems();

        if (listData.size() == 0) {
            if (loadArrayFiles) {
                listData = getListData();
            }

            fileListAdapter = new FileListAdapter(getContext(), R.layout.file_row_item, listData);
        } else {
            fileListAdapter = new FileListAdapter(getContext(), R.layout.file_row_item, retainedListDataFragment.getFileListItems());
        }

        fileListAdapter.setOnAdapterInteractionListener(this);
        fileListView.setAdapter(fileListAdapter);
    }

    @Override
    public void onDestroy() {
        super.onDestroy();

        ArrayList<FileListItem> fileListItems = new ArrayList<FileListItem>();

        for (int i = 0; i < fileListAdapter.getCount(); i++) {
            fileListItems.add(fileListAdapter.getItem(i));
        }

        retainedListDataFragment.setFileListItems(fileListItems);
    }

    @Override
    public void onClick(View v) {
        switch (v.getId()) {
            case R.id.imageButtonAddFile:
                DialogAddFile dialogAddFile = new DialogAddFile();
                dialogAddFile.setTargetFragment(this, DIALOG_ADD_FILE);
                dialogAddFile.show(fragmentManager, DialogAddFile.FRAGMENT_TAG);

                break;
        }
    }

    @Override
    public void onActivityResult(int requestCode, int resultCode, Intent data) {
        super.onActivityResult(requestCode, resultCode, data);

        switch (requestCode) {
            case DIALOG_ADD_FILE:
                switch (resultCode) {
                    case Activity.RESULT_OK:
                        String fileName = data.getExtras().getString("fileName");
                        int timeDownload = data.getExtras().getInt("timeDownload", 0);
                        fileListAdapter.insert(getListItem(fileName, timeDownload, FileListFragment.FILE_NOT_DOWNLOADED), 0);
                        fileListAdapter.notifyDataSetChanged();

                        break;
                }

                break;
        }
    }

    private FileListItem getListItem(String fileName, int timeDownload, int fileState) {
        FileListItem listItemData = new FileListItem();
        listItemData.setFileName(fileName);
        listItemData.setTimeDownload(timeDownload);
        listItemData.setFileState(fileState);

        return listItemData;
    }

    @Override
    public void onEventButtonClick(int position) {
        mListener.callbackEventFileDownload(fileListAdapter.getItem(position));
    }

    public void taskState(int state, FileListItem fileListItem) {
        switch (state) {
            case RetainedFileDownloaderFragment.TASK_START_DOWNLOADING:
                fileListAdapter.getItem(fileListAdapter.getPosition(fileListItem)).setFileState(FileListFragment.FILE_DOWNLOADING);
                fileListAdapter.notifyDataSetChanged();

                break;
            case RetainedFileDownloaderFragment.TASK_COMPLETE_DOWNLOADING:
                fileListAdapter.getItem(fileListAdapter.getPosition(fileListItem)).setFileState(FileListFragment.FILE_DOWNLOADED);
                fileListAdapter.notifyDataSetChanged();

                break;
            case RetainedFileDownloaderFragment.TASK_CANCEL_DOWNLOADING:
                fileListAdapter.getItem(fileListAdapter.getPosition(fileListItem)).setFileState(FileListFragment.FILE_NOT_DOWNLOADED);
                fileListAdapter.notifyDataSetChanged();

                break;
        }
    }

    public interface OnFragmentInteractionListener {
        void callbackEventFileDownload(FileListItem fileListItem);
    }
}
