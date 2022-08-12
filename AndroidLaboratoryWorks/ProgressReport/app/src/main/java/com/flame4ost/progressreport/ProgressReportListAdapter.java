package com.flame4ost.progressreport;

import android.content.Context;
import android.support.annotation.LayoutRes;
import android.support.annotation.NonNull;
import android.support.annotation.Nullable;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.ImageView;
import android.widget.TextView;

import java.util.ArrayList;
import java.util.List;

/**
 * Created by gogulov on 20.10.2020.
 */

public class ProgressReportListAdapter extends ArrayAdapter<ListItem> {
    private LayoutInflater inflater;
    private int listRowItem;
    private ArrayList<ListItem> listData;

    public ProgressReportListAdapter(@NonNull Context context, @LayoutRes int resource, @NonNull ArrayList<ListItem> objects) {
        super(context, resource, objects);
        this.inflater = LayoutInflater.from(context);
        this.listRowItem = resource;
        this.listData = objects;
    }

    @NonNull
    @Override
    public View getView(int position, @Nullable View convertView, @NonNull ViewGroup parent) {
        ViewHolder holder;
        if (convertView == null) {
            convertView = inflater.inflate(listRowItem, parent, false);
            holder = new ViewHolder();
            holder.textViewSurname = (TextView) convertView.findViewById(R.id.textViewSurname);
            holder.textViewName = (TextView) convertView.findViewById(R.id.textViewName);
            holder.textViewMiddleName = (TextView) convertView.findViewById(R.id.textViewMiddleName);
            holder.textViewCountMark = (TextView) convertView.findViewById(R.id.textViewCountMark);
            holder.textViewLastMark = (TextView) convertView.findViewById(R.id.textViewLastMark);
            convertView.setTag(holder);

        } else {
            holder = (ViewHolder) convertView.getTag();
        }

        ListItem newsItem = listData.get(position);
        holder.textViewSurname.setText(newsItem.getSurname());
        holder.textViewName.setText(newsItem.getName());
        holder.textViewMiddleName.setText(newsItem.getMiddleName());

        ArrayList<Mark> markData = newsItem.getMarkArrayList();

        if (markData.size() == 0) {
            holder.textViewCountMark.setText("Count mark\n" + "0");
            holder.textViewLastMark.setText("-");
        } else {
            Mark mark = markData.get(markData.size() - 1);

            holder.textViewCountMark.setText("Count mark\n" + markData.size());
            holder.textViewLastMark.setText(Integer.toString(mark.getMark()));
        }

        return convertView;
    }

    static class ViewHolder {
        TextView textViewSurname, textViewName, textViewMiddleName, textViewCountMark, textViewLastMark;
    }
}
