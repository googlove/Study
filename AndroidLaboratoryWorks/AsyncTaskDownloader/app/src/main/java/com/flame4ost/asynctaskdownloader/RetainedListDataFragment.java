package com.flame4ost.asynctaskdownloader;


import android.os.Bundle;
import android.support.annotation.Nullable;
import android.support.v4.app.Fragment;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.TextView;

import java.util.ArrayList;

public class RetainedListDataFragment extends Fragment {
    public static final String FRAGMENT_TAG = "RetainedListDataFragment";

    private ArrayList<FileListItem> fileListItems = new ArrayList<FileListItem>();

    public RetainedListDataFragment() {

    }

    @Override
    public void onCreate(@Nullable Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);

        setRetainInstance(true);
    }

    public ArrayList<FileListItem> getFileListItems() {
        return fileListItems;
    }

    public void setFileListItems(ArrayList<FileListItem> fileListItems) {
        this.fileListItems = fileListItems;
    }
}
