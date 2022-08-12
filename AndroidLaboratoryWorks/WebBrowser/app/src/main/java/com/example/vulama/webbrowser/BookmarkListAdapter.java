package com.example.vulama.webbrowser;

import android.content.Context;
import android.support.annotation.NonNull;
import android.support.annotation.Nullable;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.TextView;

import java.util.ArrayList;

//whole adapter was copied almost completely from link:
//https://www.youtube.com/watch?v=E6vE8fqQPTE

public class BookmarkListAdapter extends ArrayAdapter<Bookmark> {

    //declaration of needed variables for object derived from this class to work

    private static final String TAG="PersonalListAdapter";
    private Context mContext;
    int mResource;

    //constructor that sets up values if they are given at the initialization of object derived from this class

    public BookmarkListAdapter(@NonNull Context context, int resource, @NonNull ArrayList<Bookmark> objects, Context mContext) {
        super(context, resource, objects);
        this.mContext = mContext;
        this.mResource= resource;
    }

    //method that fills listView with data

    @NonNull
    @Override
    public View getView(int position, @Nullable View convertView, @NonNull ViewGroup parent) {

        //getting string by using item position as a reference

        String name=getItem(position).getName();
        String address=getItem(position).getAddress();

        //creating object from class Bookmark

        Bookmark bookmark=new Bookmark(name,address);

        //inflating listView elements which are defined in mResoruce (for example list_item_book.xml can be one of values for mResource)

        LayoutInflater inflater=LayoutInflater.from(mContext);
        convertView =inflater.inflate(mResource,parent,false);

        //connecting specific variables with elements by using elements id

        TextView book_name =(TextView)convertView.findViewById(R.id.Name);
        TextView book_address =(TextView)convertView.findViewById(R.id.Address);

        //filling elements with retrieved values in step described above

        book_name.setText(name);
        book_address.setText(address);

        return convertView;
    }
}
