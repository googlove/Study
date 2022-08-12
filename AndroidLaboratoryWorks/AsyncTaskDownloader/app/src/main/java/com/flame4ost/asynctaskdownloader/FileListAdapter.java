package com.flame4ost.asynctaskdownloader;

import android.content.Context;
import android.support.annotation.NonNull;
import android.support.annotation.Nullable;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.ImageButton;
import android.widget.ImageView;
import android.widget.TextView;

import java.util.ArrayList;

/**
 * Created by gogulov on 25.11.2020.
 */

public class FileListAdapter extends ArrayAdapter<FileListItem> implements View.OnClickListener{
    private LayoutInflater inflater;
    private int listRowItem;
    private ArrayList<FileListItem> listData;

    private OnAdapterInteractionListener mListener;

    public FileListAdapter(@NonNull Context context, int resource, @NonNull ArrayList<FileListItem> objects) {
        super(context, resource, objects);
        this.inflater = LayoutInflater.from(context);
        this.listRowItem = resource;
        this.listData = objects;
    }

    public void setOnAdapterInteractionListener(OnAdapterInteractionListener mListener) {
        this.mListener = mListener;
    }

    @NonNull
    @Override
    public View getView(int position, @Nullable View convertView, @NonNull ViewGroup parent) {
        ViewHolder holder;

        if (convertView == null) {
            convertView = inflater.inflate(listRowItem, parent, false);
            holder = new ViewHolder();
            holder.imageViewFileIcon = (ImageView) convertView.findViewById(R.id.imageViewFileIcon);
            holder.textViewFileName = (TextView) convertView.findViewById(R.id.textViewFileName);
            holder.textViewTimeDownload = (TextView) convertView.findViewById(R.id.textViewTimeDownload);
            holder.imageButtonFileDownload = (ImageButton) convertView.findViewById(R.id.imageButtonFileDownload);

            convertView.setTag(holder);
        } else {
            holder = (ViewHolder) convertView.getTag();
        }

        FileListItem listItemData = listData.get(position);

        switch (listItemData.getFileState()) {
            case FileListFragment.FILE_NOT_DOWNLOADED:
                holder.imageViewFileIcon.setImageDrawable(getContext().getResources().getDrawable(R.drawable.file_not_downloaded));
                holder.imageButtonFileDownload.setImageDrawable(getContext().getResources().getDrawable(R.drawable.download_file));

                holder.imageButtonFileDownload.setOnClickListener(this);

                break;
            case FileListFragment.FILE_DOWNLOADING:
                holder.imageViewFileIcon.setImageDrawable(getContext().getResources().getDrawable(R.drawable.file_not_downloaded));
                holder.imageButtonFileDownload.setImageDrawable(getContext().getResources().getDrawable(R.drawable.downloading_progress_wait));

                holder.imageButtonFileDownload.setOnClickListener(null);

                break;
            case FileListFragment.FILE_DOWNLOADED:
                holder.imageViewFileIcon.setImageDrawable(getContext().getResources().getDrawable(R.drawable.file_downloaded));
                holder.imageButtonFileDownload.setImageDrawable(getContext().getResources().getDrawable(R.drawable.downloading_progress_ok));

                holder.imageButtonFileDownload.setOnClickListener(null);

                break;
        }

        holder.imageButtonFileDownload.setTag(position);

        holder.textViewFileName.setText(listItemData.getFileName());
        holder.textViewTimeDownload.setText(Integer.toString(listItemData.getTimeDownload()) + " sec");

        return convertView;
    }

    @Override
    public void onClick(View v) {
        switch (v.getId()) {
            case R.id.imageButtonFileDownload:
                mListener.onEventButtonClick((int) v.getTag());

                break;
        }
    }

    static class ViewHolder {
        ImageView imageViewFileIcon;
        TextView textViewFileName, textViewTimeDownload;
        ImageButton imageButtonFileDownload;
    }

    public interface OnAdapterInteractionListener {
        void onEventButtonClick(int position);
    }
}
