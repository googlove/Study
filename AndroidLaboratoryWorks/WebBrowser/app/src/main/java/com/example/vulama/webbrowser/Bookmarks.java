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
import android.text.TextUtils;
import android.util.Log;
import android.view.MenuItem;
import android.view.View;
import android.view.inputmethod.InputMethodManager;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ListView;
import android.widget.Toast;

import java.io.BufferedReader;
import java.io.File;
import java.io.FileNotFoundException;
import java.io.IOException;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.io.OutputStreamWriter;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.jar.Attributes;

//defining class Bookmarks that is one of three main activities
//implements part is needed so that program knows what does it have to watch out for

public class Bookmarks extends AppCompatActivity implements AdapterView.OnItemClickListener, AdapterView.OnItemLongClickListener {

    //declaration of needed variables, only three in whole layout so we need only them for whole view

    private DrawerLayout drawer;
    private ListView listView;
    private int a=0;

    //method onCreate is deployed on the first opening of the activity
    //everything to do with showing data in listView is implemented somewhere in this method

    @Override
    protected void onCreate(Bundle savedInstanceState) {

        //two instructions on every onCreate method, important if you delete this part application will not work properly

        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_bookmarks);

        //initialization of listView element by using its id from xml file

        ListView listView = (ListView) findViewById(R.id.Bookmark_list);

        //checking if there is something written in file that contains names of bookmark
        //if the file is empty there is nothing to be shown so this whole block of instruction is being skipped
        //because NameBook.txt and AddressBook.txt are being accessed in the same part of the code we need to check only one
        //if one is empty the other one will be empty as well

        if(Read(Bookmarks.this,"NameBook.txt")!="") {

            //declaration and initialization of string values for names and addresses
            //string red from the file contains all addresses and names in one line that are separated by my control sign
            //when the string is retrieved it is split by that control sing and thats why we have string array as a type of variable

            String[] Names = Read(Bookmarks.this, "NameBook.txt").split("↨");
            String[] Address = Read(Bookmarks.this, "AddressBook.txt").split("↨");

            //filling objects for custom list adapter with the retrieved data from code above

            ArrayList<Bookmark> bookmarkList = new ArrayList<>();
            for (int i = 0; i < Names.length; i++) {
                Bookmark data = new Bookmark(Names[i], Address[i]);
                bookmarkList.add(data);
            }

            //showing retrieved data int listView from instructions showed above

            BookmarkListAdapter adapter = new BookmarkListAdapter(getApplicationContext(), R.layout.list_item_book, bookmarkList, getApplicationContext());
            listView.setAdapter(adapter);
        }

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
                        Intent intent=new Intent(Bookmarks.this,UrlSearch.class);
                        intent.putExtra("url_address",Read(getApplicationContext(),"LastPage.txt"));
                        startActivity(intent);
                        overridePendingTransition(R.anim.slide_in_right,R.anim.slide_out_left);
                        break;
                    case R.id.bookmark:
                        break;
                    case R.id.history:
                        intent=new Intent(getApplicationContext(),History.class);
                        startActivity(intent);
                        overridePendingTransition(R.anim.slide_in_left,R.anim.slide_out_right);
                        break;
                    case R.id.add_book:

                        break;
                    case R.id.incognito:
                        if(Read(Bookmarks.this,"incognito.txt").equals("0")) {
                            Write("1", Bookmarks.this, "incognito.txt");
                            Toast.makeText(Bookmarks.this,"Incognito ON",Toast.LENGTH_SHORT).show();
                            Intent intentn = getIntent();
                            finish();
                            startActivity(intentn);
                        }else{
                            Write("0", Bookmarks.this, "incognito.txt");
                            Toast.makeText(Bookmarks.this,"Incognito OFF",Toast.LENGTH_SHORT).show();
                            Intent intentn = getIntent();
                            finish();
                            startActivity(intentn);
                        }
                        break;
                    case R.id.homepage:
                        AlertDialog.Builder b = new AlertDialog.Builder(Bookmarks.this);
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
                                Toast.makeText(getApplicationContext(),"Bookmarks is not valid web address",Toast.LENGTH_SHORT).show();
                            }
                        });
                        Default.setOnClickListener(new View.OnClickListener() {
                            @Override
                            public void onClick(View v) {
                                Write("", Bookmarks.this, "Homepage.txt");
                                d.dismiss();
                            }
                        });
                        Entered.setOnClickListener(new View.OnClickListener() {
                            @Override
                            public void onClick(View v) {
                                Write(address.getText().toString(), Bookmarks.this, "Homepage.txt");
                                d.dismiss();
                                a=0;
                            }
                        });
                        break;
                    case R.id.search_engine:
                        AlertDialog.Builder b1=new AlertDialog.Builder(Bookmarks.this);
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
                                Write("0",Bookmarks.this,"searchengine.txt");
                                Toast.makeText(Bookmarks.this,"Search engine Google",Toast.LENGTH_SHORT).show();
                            }
                        });
                        bing.setOnClickListener(new View.OnClickListener() {
                            @Override
                            public void onClick(View v) {
                                Write("1",Bookmarks.this,"searchengine.txt");
                                Toast.makeText(Bookmarks.this,"Search engine Bing",Toast.LENGTH_SHORT).show();
                            }
                        });
                        yahoo.setOnClickListener(new View.OnClickListener() {
                            @Override
                            public void onClick(View v) {
                                Write("2",Bookmarks.this,"searchengine.txt");
                                Toast.makeText(Bookmarks.this,"Search engine Yahoo",Toast.LENGTH_SHORT).show();
                            }
                        });
                        break;
                }
                return true;
            }
        });

        //properties of the listView that enables us to click on them and get elements of listView interactive

        listView.setItemsCanFocus(true);
        listView.setOnItemClickListener(this);
        listView.setOnItemLongClickListener(this);

    }

    //function that retrieves string data from given file
    //retrieves line by line if there is multiple lines written inside a file

    private String Read(Context context,String filename){

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

    //function that writes string type of data into given file

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

    //method that redirects us from Bookmarks activity to UrlSearch activity by using address stored in file

    @Override
    public void onItemClick(AdapterView<?> parent, View view, int position, long id) {

        //by using position of the item (integer value) we can retrieve web address stored inside AddressBook.txt file

        String[] Address = Read(Bookmarks.this, "AddressBook.txt").split("↨");
        String item=Address[position];

        //creating new intent that will switch activity from Bookmarks to UrlSearch

        Intent intent=new Intent(Bookmarks.this,UrlSearch.class);

        //sending data implemented in intent by using keyword

        intent.putExtra("url_address",item);

        //starting that intent

        startActivity(intent);
    }

    //function that on long press on one of the items pops up delete dialog box

    @Override
    public boolean onItemLongClick(AdapterView<?> parent, View view, final int position, long id) {

        //inflating delete dialog box and initializing button on that layout

        AlertDialog.Builder builder=new AlertDialog.Builder(Bookmarks.this);
        view=getLayoutInflater().inflate(R.layout.dialog_layout_delete,null);
        Button Delete=(Button) view.findViewById(R.id.button);
        Delete.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {

                //method that deploys with a push of a button
                //by a lot of parsing we are getting which one we should delete

                String[] Address = Read(Bookmarks.this, "AddressBook.txt").split("↨");
                String[] Names = Read(Bookmarks.this, "NameBook.txt").split("↨");
                ArrayList<String> name =new ArrayList<>();
                ArrayList<String> address =new ArrayList<>();
                for(int i=0;i<Names.length;i++){
                    name.add(Names[i]);
                    address.add(Address[i]);
                }
                name.remove(position);
                address.remove(position);
                Address=new String[name.size()];
                Names=new String[name.size()];
                for(int i=0;i<name.size();i++){
                    Names[i]=name.get(i);
                    Address[i]=address.get(i);
                }
                String SaveName=Names[0];
                String SaveAddress=Address[0];
                for(int i=1;i<name.size();i++){
                    SaveName=SaveName+"↨"+Names[i];
                    SaveAddress=SaveAddress+"↨"+Address[i];
                }
                Write(SaveName,Bookmarks.this,"NameBook.txt");
                Write(SaveAddress,Bookmarks.this,"AddressBook.txt");
                finish();
                startActivity(getIntent());
            }
        });

        //showing dialog box that we inflated earlier (earlier in code not in execution)

        builder.setView(view);
        AlertDialog dialog=builder.create();
        dialog.getWindow().setBackgroundDrawable(new ColorDrawable(Color.TRANSPARENT));
        dialog.show();
        return true;
    }
}
