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

public class MarkDataListAdapter extends ArrayAdapter<Mark> {
    private LayoutInflater inflater;
    private int listRowItem;
    private ArrayList<Mark> markData;

    public MarkDataListAdapter(@NonNull Context context, @LayoutRes int resource, @NonNull ArrayList<Mark> objects) {
        super(context, resource, objects);
        this.inflater = LayoutInflater.from(context);
        this.listRowItem = resource;
        this.markData = objects;
    }

    @NonNull
    @Override
    public View getView(int position, @Nullable View convertView, @NonNull ViewGroup parent) {
        ViewHolder holder;
        if (convertView == null) {
            convertView = inflater.inflate(listRowItem, parent, false);
            holder = new ViewHolder();
            holder.textViewDateMark = (TextView) convertView.findViewById(R.id.textViewDateMark);
            holder.textViewMark = (TextView) convertView.findViewById(R.id.textViewMark);
            convertView.setTag(holder);

        } else {
            holder = (ViewHolder) convertView.getTag();
        }

        Mark newMark = markData.get(position);

        String dateMark = newMark.getYear() + "." + newMark.getMonth() + "." + newMark.getDate() + "\n" + newMark.getHour() + ":" + newMark.getMinute() + ":" + newMark.getSecond();

        holder.textViewDateMark.setText(dateMark);
        holder.textViewMark.setText(Integer.toString(newMark.getMark()));

        return convertView;
    }

    static class ViewHolder {
        TextView textViewDateMark, textViewMark;
    }
}
