package com.example.vulama.webbrowser;

import android.app.Activity;
import android.app.AlertDialog;
import android.app.ProgressDialog;
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
import android.view.KeyEvent;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.view.inputmethod.EditorInfo;
import android.view.inputmethod.InputMethodManager;
import android.widget.Button;
import android.widget.EditText;
import android.widget.TextView;
import android.widget.Toast;

import java.io.BufferedReader;
import java.io.FileNotFoundException;
import java.io.IOException;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.io.OutputStreamWriter;

public class HomeActivity extends AppCompatActivity implements View.OnClickListener
{

    //initialization of needed variables/objects

    private Button SearchButtonHome;
    private EditText InputURL;
    private DrawerLayout drawer;

    //method onCreate is deployed on the first opening of the activity

    @Override
    protected void onCreate(Bundle savedInstanceState) {

        //two instructions on every onCreate method, important if you delete this part application will not work properly

        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_home);

        //checking if homepage is set to some random page or default

        if(Read(HomeActivity.this,"Homepage.txt")!=""){

            //if homepage is set to random address than we open that address

            Intent intent =new Intent(HomeActivity.this,UrlSearch.class);
            intent.putExtra("url_address",Read(HomeActivity.this,"Homepage.txt"));
            Write("nes",HomeActivity.this,"state.txt");
            finish();
            startActivity(intent);
        }else{

            //if the homepage is set do default we continue to execute code from this activity

            Write("",HomeActivity.this,"state.txt");

            //next block of code is used to setup navigationView elements
            //declaration and initialization of drawer layout (type of layout) by his id

            drawer = findViewById(R.id.drawer_layout);
            NavigationView navigationView = findViewById(R.id.nav_view);

            //switch case operated by comparing id-s of the clicked items
            //get getItemId property of object gives us id that corresponds with id defined in xml file of specific item

            navigationView.setNavigationItemSelectedListener(new NavigationView.OnNavigationItemSelectedListener() {
                @Override
                public boolean onNavigationItemSelected(@NonNull MenuItem item) {
                    switch (item.getItemId()) {
                        case R.id.search_engine:
                            AlertDialog.Builder b1=new AlertDialog.Builder(HomeActivity.this);
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
                                    Write("0",HomeActivity.this,"searchengine.txt");
                                    Toast.makeText(HomeActivity.this,"Search engine Google",Toast.LENGTH_SHORT).show();
                                }
                            });
                            bing.setOnClickListener(new View.OnClickListener() {
                                @Override
                                public void onClick(View v) {
                                    Write("1",HomeActivity.this,"searchengine.txt");
                                    Toast.makeText(HomeActivity.this,"Search engine Bing",Toast.LENGTH_SHORT).show();
                                }
                            });
                            yahoo.setOnClickListener(new View.OnClickListener() {
                                @Override
                                public void onClick(View v) {
                                    Write("2",HomeActivity.this,"searchengine.txt");
                                    Toast.makeText(HomeActivity.this,"Search engine Yahoo",Toast.LENGTH_SHORT).show();
                                }
                            });
                            break;

                        case R.id.incognito:
                            if(Read(HomeActivity.this,"incognito.txt").equals("0")) {
                                Write("1", HomeActivity.this, "incognito.txt");
                                Toast.makeText(HomeActivity.this,"Incognito ON",Toast.LENGTH_SHORT).show();
                                Intent intentn = getIntent();
                                finish();
                                startActivity(intentn);
                            }else{
                                Write("0", HomeActivity.this, "incognito.txt");
                                Toast.makeText(HomeActivity.this,"Incognito OFF",Toast.LENGTH_SHORT).show();
                                Intent intentn = getIntent();
                                finish();
                                startActivity(intentn);
                            }
                            break;
                        case R.id.homepage:
                            AlertDialog.Builder b=new AlertDialog.Builder(HomeActivity.this);
                            View v=getLayoutInflater().inflate(R.layout.dialog_layout_homepage,null);
                            final EditText address=(EditText) v.findViewById(R.id.editText);
                            b.setView(v);
                            final AlertDialog d=b.create();
                            d.getWindow().setBackgroundDrawable(new ColorDrawable(Color.TRANSPARENT));
                            d.show();
                            Button Current=(Button) v.findViewById(R.id.current);
                            Button Default=(Button) v.findViewById(R.id.def);
                            Button Entered=(Button) v.findViewById(R.id.entered);
                            Current.setOnClickListener(new View.OnClickListener() {
                                @Override
                                public void onClick(View v) {
                                    Write("",HomeActivity.this,"Homepage.txt");
                                    d.dismiss();
                                }
                            });
                            Default.setOnClickListener(new View.OnClickListener() {
                                @Override
                                public void onClick(View v) {
                                    Write("",HomeActivity.this,"Homepage.txt");
                                    d.dismiss();
                                }
                            });
                            Entered.setOnClickListener(new View.OnClickListener() {
                                @Override
                                public void onClick(View v) {
                                    Write(address.getText().toString(),HomeActivity.this,"Homepage.txt");
                                    d.dismiss();
                                }
                            });
                            break;
                        case R.id.web:
                            Intent intent = new Intent(HomeActivity.this, UrlSearch.class);
                            intent.putExtra("url_address", Read(getApplicationContext(), "LastPage.txt"));
                            startActivity(intent);
                            overridePendingTransition(R.anim.slide_in_left, R.anim.slide_out_right);
                            break;
                        case R.id.bookmark:
                            intent = new Intent(getApplicationContext(), Bookmarks.class);
                            startActivity(intent);
                            overridePendingTransition(R.anim.slide_in_left, R.anim.slide_out_right);
                            break;
                        case R.id.history:
                            intent = new Intent(getApplicationContext(), History.class);
                            startActivity(intent);
                            overridePendingTransition(R.anim.slide_in_left, R.anim.slide_out_right);
                            break;
                        case R.id.add_book:

                            break;
                        case R.id.google_short:
                            Intent Open_google = new Intent(HomeActivity.this, UrlSearch.class);
                            Open_google.putExtra("url_address", "https://google.com");
                            startActivity(Open_google);
                            overridePendingTransition(R.anim.slide_in_left, R.anim.slide_out_right);
                            break;
                        case R.id.facebook_short:
                            Intent Open_facebook = new Intent(HomeActivity.this, UrlSearch.class);
                            Open_facebook.putExtra("url_address", "https://facebook.com");
                            startActivity(Open_facebook);
                            overridePendingTransition(R.anim.slide_in_left, R.anim.slide_out_right);
                            break;
                        case R.id.youtube_short:
                            Intent Open_youtube = new Intent(HomeActivity.this, UrlSearch.class);
                            Open_youtube.putExtra("url_address", "https://youtube.com");
                            startActivity(Open_youtube);
                            overridePendingTransition(R.anim.slide_in_left, R.anim.slide_out_right);
                            break;
                        case R.id.instagram_short:
                            Intent Open_instagram = new Intent(HomeActivity.this, UrlSearch.class);
                            Open_instagram.putExtra("url_address", "https://instagram.com");
                            startActivity(Open_instagram);
                            overridePendingTransition(R.anim.slide_in_left, R.anim.slide_out_right);
                            break;
                        case R.id.tsrb_short:
                            Intent Open_tsrb = new Intent(HomeActivity.this, UrlSearch.class);
                            Open_tsrb.putExtra("url_address", "http://www.tsrb.hr/");
                            startActivity(Open_tsrb);
                            overridePendingTransition(R.anim.slide_in_left, R.anim.slide_out_right);
                            break;
                    }
                    return true;
                }
            });

            //initializing objects that we need for the rest of the program

            SearchButtonHome = (Button) findViewById(R.id.search_button_home);
            InputURL = (EditText) findViewById(R.id.search_home);

            //using method so we have search button instead of enter button on our keyboard

            InputURL.setImeOptions(EditorInfo.IME_ACTION_SEARCH);
            InputURL.setOnEditorActionListener(new TextView.OnEditorActionListener() {
                @Override
                public boolean onEditorAction(TextView v, int actionId, KeyEvent event) {
                    if(actionId==EditorInfo.IME_ACTION_SEARCH){
                        OpenWebSite();
                        return true;
                    }
                    return false;
                }
            });

            //makes cursor visible
            InputURL.setCursorVisible(false);

            //methods that expect click on button/input field

            SearchButtonHome.setOnClickListener(this);
            InputURL.setOnClickListener(this);
        }


    }

    //method that resolves onClick events

    @Override
    public void onClick(View view) {
        if(view==InputURL){
            //makes cursor visible
            InputURL.setCursorVisible(true);
        }
        if(view==SearchButtonHome){
            //starts method
            OpenWebSite();
        }
    }

    private void OpenWebSite() {
        String Url_Address=InputURL.getText().toString();
        if(TextUtils.isEmpty(Url_Address)){
            Toast empty=Toast.makeText(HomeActivity.this,"Please enter Url or Web Address",Toast.LENGTH_LONG);
            empty.show();
        }else{

            //if input field has any of this conditions we expect that it is imputed web address

            if(!(Url_Address.contains("://"))){

                //searching web by keyword using one of the search engines (one that is selected)

                Intent search = new Intent(HomeActivity.this, UrlSearch.class);
                if(Read(HomeActivity.this,"searchengine.txt").equals("0")) {
                    search.putExtra("url_address", "https://www.google.hr/search?q=" + Url_Address + "&ie=&oe=");
                }else if(Read(HomeActivity.this,"searchengine.txt").equals("1")){
                    search.putExtra("url_address", "https://www.bing.com/search?q=" + Url_Address + "&qs=n&form=QBLH&sp=-1&pq=" + Url_Address + "&sc=8-5&sk=&cvid=3F0E1B34946D4F9DA957278A25AA9CCB");
                }else if(Read(HomeActivity.this,"searchengine.txt").equals("2")){
                    search.putExtra("url_address", "https://search.yahoo.com/search?p=" + Url_Address + "&fr=yfp-t&fp=1&toggle=1&cop=mss&ei=UTF-8");
                }
                startActivity(search);

            }else {

                //searching exact web address

                Intent search = new Intent(HomeActivity.this, UrlSearch.class);
                search.putExtra("url_address",Url_Address );
                startActivity(search);

            }
        }

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
}
