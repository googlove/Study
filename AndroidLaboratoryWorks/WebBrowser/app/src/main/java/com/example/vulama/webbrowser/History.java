package com.example.vulama.webbrowser;

import android.app.AlertDialog;
import android.content.Context;
import android.content.Intent;
import android.graphics.Color;
import android.graphics.drawable.ColorDrawable;
import android.support.annotation.NonNull;
import android.support.design.widget.NavigationView;
import android.support.v4.widget.DrawerLayout;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.util.Log;
import android.view.MenuItem;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.EditText;
import android.widget.HorizontalScrollView;
import android.widget.ListView;
import android.widget.Toast;

import java.io.BufferedReader;
import java.io.FileNotFoundException;
import java.io.IOException;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.io.OutputStreamWriter;
import java.text.DateFormat;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.Date;
import java.util.List;

public class History extends AppCompatActivity implements AdapterView.OnItemClickListener {

    //initialization of needed objects

    private ListView listView;
    private DrawerLayout drawer;
    private int a=0;

    //method onCreate is deployed on the first opening of the activity
    //everything to do with showing data in listView is implemented somewhere in this method

    @Override
    protected void onCreate(Bundle savedInstanceState) {

        //two instructions on every onCreate method, important if you delete this part application will not work properly

        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_history);

        //next block of code is used to setup navigationView elements
        //declaration and initialization of drawer layout (type of layout) by his id

        drawer=findViewById(R.id.drawer_layout);
        NavigationView navigationView =findViewById(R.id.nav_view);

        //switch case operated by comparing id-s of the clicked items
        //get getItemId property of object gives us id that corresponds with id defined in xml file of specific item

        navigationView.setNavigationItemSelectedListener(new NavigationView.OnNavigationItemSelectedListener() {
            @Override
            public boolean onNavigationItemSelected(@NonNull MenuItem item) {
                switch (item.getItemId()){
                    case R.id.web:
                        Intent intent=new Intent(History.this,UrlSearch.class);
                        intent.putExtra("url_address",Read(getApplicationContext(),"LastPage.txt"));
                        startActivity(intent);
                        overridePendingTransition(R.anim.slide_in_right,R.anim.slide_out_left);
                        break;
                    case R.id.bookmark:
                        intent=new Intent(getApplicationContext(),Bookmarks.class);
                        startActivity(intent);
                        overridePendingTransition(R.anim.slide_in_left,R.anim.slide_out_right);
                        break;
                    case R.id.history:

                        break;
                    case R.id.add_book:

                        break;
                    case R.id.incognito:
                        if(Read(History.this,"incognito.txt").equals("0")) {
                            Write("1", History.this, "incognito.txt");
                            Toast.makeText(History.this,"Incognito ON",Toast.LENGTH_SHORT).show();
                            Intent intentn = getIntent();
                            finish();
                            startActivity(intentn);
                        }else{
                            Write("0", History.this, "incognito.txt");
                            Toast.makeText(History.this,"Incognito OFF",Toast.LENGTH_SHORT).show();
                            Intent intentn = getIntent();
                            finish();
                            startActivity(intentn);
                        }
                        break;
                    case R.id.homepage:
                        AlertDialog.Builder b = new AlertDialog.Builder(History.this);
                        View v = getLayoutInflater().inflate(R.layout.dialog_layout_homepage, null);
                        final EditText address = (EditText) v.findViewById(R.id.editText);
                        b.setView(v);
                        final AlertDialog d = b.create();
                        d.getWindow().setBackgroundDrawable(new ColorDrawable(Color.TRANSPARENT));
                        d.show();
                        Button Current = (Button) v.findViewById(R.id.current);
                        Button Default = (Button) v.findViewById(R.id.def);
                        Button Entered = (Button) v.findViewById(R.id.entered);
                        Current.setOnClickListener(new View.OnClickListener() {
                            @Override
                            public void onClick(View v) {
                                Toast.makeText(getApplicationContext(),"History is not valid web address",Toast.LENGTH_SHORT).show();
                            }
                        });
                        Default.setOnClickListener(new View.OnClickListener() {
                            @Override
                            public void onClick(View v) {
                                Write("", History.this, "Homepage.txt");
                                d.dismiss();
                            }
                        });
                        Entered.setOnClickListener(new View.OnClickListener() {
                            @Override
                            public void onClick(View v) {
                                Write(address.getText().toString(), History.this, "Homepage.txt");
                                d.dismiss();
                                a=0;
                            }
                        });
                        break;
                    case R.id.search_engine:
                        AlertDialog.Builder b1=new AlertDialog.Builder(History.this);
                        View v1=getLayoutInflater().inflate(R.layout.dialog_search_engine,null);
                        b1.setView(v1);
                        final AlertDialog d1 = b1.create();
                        d1.getWindow().setBackgroundDrawable(new ColorDrawable(Color.TRANSPARENT));
                        d1.show();
                        Button google = (Button) v1.findViewById(R.id.google);
                        Button bing = (Button) v1.findViewById(R.id.bing);
                        Button yahoo = (Button) v1.findViewById(R.id.yahoo);
                        google.setOnClickListener(new View.OnClickListener() {
                            @Override
                            public void onClick(View v) {
                                Write("0",History.this,"searchengine.txt");
                                Toast.makeText(History.this,"Search engine Google",Toast.LENGTH_SHORT).show();
                            }
                        });
                        bing.setOnClickListener(new View.OnClickListener() {
                            @Override
                            public void onClick(View v) {
                                Write("1",History.this,"searchengine.txt");
                                Toast.makeText(History.this,"Search engine Bing",Toast.LENGTH_SHORT).show();
                            }
                        });
                        yahoo.setOnClickListener(new View.OnClickListener() {
                            @Override
                            public void onClick(View v) {
                                Write("2",History.this,"searchengine.txt");
                                Toast.makeText(History.this,"Search engine Yahoo",Toast.LENGTH_SHORT).show();
                            }
                        });
                        break;
                }
                return true;
            }
        });

        //initialization of listView element by using its id from xml file

        listView=(ListView)findViewById(R.id.ListView);

        //using methods Read and split we get each address search and date when it is searched

        String[] history=Read(History.this,"History.txt").split("↨");
        String[] date=Read(History.this,"date.txt").split("↨");

        ArrayList<String> his=new ArrayList<>(Arrays.asList(history));
        ArrayList<String> dat=new ArrayList<>(Arrays.asList(date));

        //deleting every record that has index over 50 (limit number of stored addresses)

        while(his.size()>50){
            his.remove(50);
            dat.remove(50);
        }
        String temp1=his.get(0);
        String temp2=dat.get(0);

        //recreating stored strings and storing them again

        for(int i=1;i<his.size();i++){
            temp1+="↨"+his.get(i);
            temp2+="↨"+dat.get(i);
        }

        Write(temp1,History.this,"History.txt");
        Write(temp2,History.this,"date.txt");

        //spliting stored string to fill array list

        history= temp1.split("↨");
        date= temp2.split("↨");

        //filling array list with data using (bookmark is type because it's the
        //same adapter that we use for bookmarks and history

        ArrayList<Bookmark> bookmarkList = new ArrayList<>();
        for (int i = 0; i < history.length; i++) {
            Bookmark cache = null;
            try {
                cache = new Bookmark(history[i], datum(date[i]));
            } catch (ParseException e) {
                e.printStackTrace();
            }
            bookmarkList.add(cache);
        }

        //using custom adapter for showing data

        BookmarkListAdapter adapter = new BookmarkListAdapter(getApplicationContext(), R.layout.list_item_history, bookmarkList, getApplicationContext());
        listView.setAdapter(adapter);
        listView.setItemsCanFocus(true);
        listView.setOnItemClickListener(this);




    }

    //method that parses two different types of date if needed

    private String datum(String s) throws ParseException {
        DateFormat dateFormat=new SimpleDateFormat("dd.MM.yyyy");
        DateFormat hm=new SimpleDateFormat("HH:mm");
        DateFormat read=new SimpleDateFormat("dd.MM.yyyy HH:mm");
        Date prev=read.parse(s);
        Date date =new Date();

        if(date.getDay()==prev.getDay() && date.getYear()==prev.getYear() && date.getMonth()==prev.getMonth()){
            return hm.format(prev);
        }else{
            return dateFormat.format(prev);
        }
    }

    //method for reading data from textual file

    private String Read(Context context, String filename){

        String ret = "";

        try {
            InputStream inputStream = context.openFileInput(filename);

            if ( inputStream != null ) {
                InputStreamReader inputStreamReader = new InputStreamReader(inputStream);
                BufferedReader bufferedReader = new BufferedReader(inputStreamReader);
                String receiveString = "";
                StringBuilder stringBuilder = new StringBuilder();

                while ( (receiveString = bufferedReader.readLine()) != null ) {
                    stringBuilder.append(receiveString);
                }

                inputStream.close();
                ret = stringBuilder.toString();
            }
        } catch (FileNotFoundException e) {
            e.printStackTrace();
        } catch (IOException e) {
            Log.e("login activity", "Can not read file: " + e.toString());
        }

        return ret;
    }

    //method for writing data into a textual file

    private void Write(String data, Context context, String filename) {
        try {
            OutputStreamWriter outputStreamWriter = new OutputStreamWriter(context.openFileOutput(filename, Context.MODE_PRIVATE));
            outputStreamWriter.write(data);
            outputStreamWriter.close();
        }
        catch (IOException e) {
            Log.e("Exception", "File write failed: " + e.toString());
        }
    }

    //method that opens web location of the history item that we clicked on

    @Override
    public void onItemClick(AdapterView<?> parent, View view, int position, long id) {
        String[] Address = Read(History.this, "History.txt").split("↨");
        String item=Address[position];
        Intent intent=new Intent(History.this,UrlSearch.class);
        intent.putExtra("url_address",item);
        startActivity(intent);
    }

}