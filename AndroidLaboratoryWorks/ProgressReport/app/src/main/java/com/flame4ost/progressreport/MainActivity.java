package com.flame4ost.progressreport;

import android.app.Dialog;
import android.graphics.Color;
import android.graphics.drawable.ColorDrawable;
import android.support.v7.app.AlertDialog;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.util.SparseBooleanArray;
import android.view.ContextMenu;
import android.view.MenuItem;
import android.view.View;
import android.widget.AdapterView;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ImageButton;
import android.widget.ImageView;
import android.widget.ListView;
import android.widget.TextView;
import android.widget.Toast;

import org.w3c.dom.Text;

import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Calendar;
import java.util.Random;

public class MainActivity extends AppCompatActivity implements AdapterView.OnItemClickListener, View.OnClickListener {
    ArrayList<ListItem> listData;
    ListView progressReportListView;
    ProgressReportListAdapter progressReportListAdapter;
    ImageButton imageButtonAddStudent, imageButtonRemoveStudent;

    AlertDialog alertDialog, alertDialogEnterName, alertDialogAllInfo, alertDialogEnterMark;
    AlertDialog.Builder builderEnterName, builderAllInfo, builderEnterMark;
    View alertDialogEnterNameView, alertDialogAllInfoView, alertDialogEnterMarkView;
    private static final int ALERT_DIALOG_ENTER_NAME = 0;
    private static final int ALERT_DIALOG_ALL_INFO = 1;
    private static final int ALERT_DIALOG_ENTER_MARK = 2;
    Button buttonOkEnterName, buttonCancelEnterName, buttonOkEnterMark, buttonCancelEnterMark;

    ArrayList<Mark> markData;
    ListView markListView;
    MarkDataListAdapter markDataListAdapter;
    ImageButton imageButtonAddMark, imageButtonRemoveMark, imageButtonExitInfoDialog;

    int itemPosition;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        alertDialogEnterNameView = getLayoutInflater().inflate(R.layout.alert_dialog_enter_full_name, null);
        alertDialogAllInfoView = getLayoutInflater().inflate(R.layout.alert_dialog_all_info, null);
        alertDialogEnterMarkView = getLayoutInflater().inflate(R.layout.alert_dialog_enter_mark, null);

        progressReportListView = (ListView) findViewById(R.id.progressReportListView);

        if (savedInstanceState == null) {
            listData = getListData();
            progressReportListAdapter = new ProgressReportListAdapter(this, R.layout.progress_report_row_item, listData);
            progressReportListView.setAdapter(progressReportListAdapter);
        } else {
            progressReportListAdapter = (ProgressReportListAdapter) getLastCustomNonConfigurationInstance();
            progressReportListView.setAdapter(progressReportListAdapter);
        }

        progressReportListView.setOnItemClickListener(this);
        registerForContextMenu(progressReportListView);

        imageButtonAddStudent = (ImageButton) findViewById(R.id.imageButtonAddStudent);
        imageButtonRemoveStudent = (ImageButton) findViewById(R.id.imageButtonRemoveStudent);

        imageButtonAddStudent.setOnClickListener(this);
        imageButtonRemoveStudent.setOnClickListener(this);

        buttonOkEnterName = (Button) alertDialogEnterNameView.findViewById(R.id.buttonOkEnterName);
        buttonCancelEnterName = (Button) alertDialogEnterNameView.findViewById(R.id.buttonCancelEnterName);

        buttonOkEnterName.setOnClickListener(this);
        buttonCancelEnterName.setOnClickListener(this);

        imageButtonAddMark = (ImageButton) alertDialogAllInfoView.findViewById(R.id.imageButtonAddMark);
        imageButtonRemoveMark = (ImageButton) alertDialogAllInfoView.findViewById(R.id.imageButtonRemoveMark);
        imageButtonExitInfoDialog = (ImageButton) alertDialogAllInfoView.findViewById(R.id.imageButtonExitInfoDialog);
        markListView = (ListView) alertDialogAllInfoView.findViewById(R.id.markListView);

        imageButtonAddMark.setOnClickListener(this);
        imageButtonRemoveMark.setOnClickListener(this);
        imageButtonExitInfoDialog.setOnClickListener(this);
        markListView.setOnItemClickListener(this);

        buttonOkEnterMark = (Button) alertDialogEnterMarkView.findViewById(R.id.buttonOkEnterMark);
        buttonCancelEnterMark = (Button) alertDialogEnterMarkView.findViewById(R.id.buttonCancelEnterMark);

        buttonOkEnterMark.setOnClickListener(this);
        buttonCancelEnterMark.setOnClickListener(this);
    }

    public ArrayList<ListItem> getListData() {
        ArrayList<ListItem> listData = new ArrayList<ListItem>();
        String[] names = getResources().getStringArray(R.array.name);
        String[] surnames = getResources().getStringArray(R.array.surname);
        String[] middleNames = getResources().getStringArray(R.array.middle_name);

        for (int i = 0; i < names.length; i++) {
            listData.add(getListItem(names[i], surnames[i], middleNames[i], new Random().nextInt(100) + 1));
        }

        return listData;
    }

    @Override
    public void onItemClick(AdapterView<?> adapterView, View view, int i, long l) {
        ImageView imageView;
        switch (adapterView.getId()) {
            case R.id.progressReportListView:
                ListItem listItem = progressReportListAdapter.getItem(i);
                imageView = (ImageView) view.findViewById(R.id.imageViewListItemChecked);

                if (progressReportListView.isItemChecked(i) == true) {
                    imageView.setImageDrawable(getResources().getDrawable(R.drawable.checkbox_checked));
                } else {
                    imageView.setImageDrawable(getResources().getDrawable(R.drawable.checkbox_unchecked));
                }

                break;
            case R.id.markListView:
                Mark mark = markDataListAdapter.getItem(i);
                imageView = (ImageView) view.findViewById(R.id.imageViewListItemChecked);

                if (markListView.isItemChecked(i) == true) {
                    imageView.setImageDrawable(getResources().getDrawable(R.drawable.checkbox_checked));
                } else {
                    imageView.setImageDrawable(getResources().getDrawable(R.drawable.checkbox_unchecked));
                }

                break;
        }
    }

    @Override
    public void onClick(View view) {
        SparseBooleanArray sparseBooleanArray;

        switch (view.getId()) {
            case R.id.imageButtonAddStudent:
                showDialog(ALERT_DIALOG_ENTER_NAME);

                break;
            case R.id.imageButtonRemoveStudent:
                sparseBooleanArray = progressReportListView.getCheckedItemPositions();
                ArrayList<ListItem> selectedListData = new ArrayList<ListItem>();

                for (int i = 0; i < progressReportListView.getCount(); i++) {
                    if (sparseBooleanArray.get(i)) {
                        selectedListData.add(progressReportListAdapter.getItem(i));
                        ((ImageView) progressReportListView.getChildAt(i).findViewById(R.id.imageViewListItemChecked)).setImageDrawable(getResources().getDrawable(R.drawable.checkbox_unchecked));
                    }
                }

                if (selectedListData.size() == 0) {
                    Toast.makeText(MainActivity.this, "No items selected", Toast.LENGTH_SHORT).show();
                } else {
                    for (int y = 0; y < selectedListData.size(); y++) {
                        progressReportListAdapter.remove(selectedListData.get(y));
                    }

                    progressReportListView.clearChoices();
                    progressReportListAdapter.notifyDataSetChanged();
                }

                break;
            case R.id.buttonOkEnterName:
                EditText editTextSurname = (EditText) alertDialogEnterNameView.findViewById(R.id.editTextSurname);
                EditText editTextName = (EditText) alertDialogEnterNameView.findViewById(R.id.editTextName);
                EditText editTextMiddleName = (EditText) alertDialogEnterNameView.findViewById(R.id.editTextMiddleName);
                EditText editTextMark = (EditText) alertDialogEnterNameView.findViewById(R.id.editTextMark);

                if (!editTextSurname.getText().toString().isEmpty() && !editTextName.getText().toString().isEmpty() && !editTextMiddleName.getText().toString().isEmpty()) {
                    if (editTextMark.getText().toString().isEmpty()) {
                        progressReportListAdapter.add(getListItem(editTextName.getText().toString(), editTextSurname.getText().toString(), editTextMiddleName.getText().toString(), -1));
                        progressReportListAdapter.notifyDataSetChanged();
                        alertDialogEnterName.dismiss();

                        clearDialogField(editTextSurname);
                        clearDialogField(editTextName);
                        clearDialogField(editTextMiddleName);
                        clearDialogField(editTextMark);
                    } else if (!editTextMark.getText().toString().isEmpty() && !editTextMark.getText().toString().equals("0")) {
                        progressReportListAdapter.add(getListItem(editTextName.getText().toString(), editTextSurname.getText().toString(), editTextMiddleName.getText().toString(), Integer.parseInt(editTextMark.getText().toString())));
                        progressReportListAdapter.notifyDataSetChanged();
                        alertDialogEnterName.dismiss();

                        clearDialogField(editTextSurname);
                        clearDialogField(editTextName);
                        clearDialogField(editTextMiddleName);
                        clearDialogField(editTextMark);
                    } else if (editTextMark.getText().toString().equals("0")) {
                        Toast.makeText(MainActivity.this, "This is an incorrect mark", Toast.LENGTH_SHORT).show();
                    }
                } else {
                    Toast.makeText(MainActivity.this, "Enter your name", Toast.LENGTH_SHORT).show();
                }

                break;
            case R.id.buttonCancelEnterName:
                alertDialogEnterName.cancel();

                break;
            case R.id.imageButtonAddMark:
                showDialog(ALERT_DIALOG_ENTER_MARK);

                break;
            case R.id.imageButtonRemoveMark:
                sparseBooleanArray = markListView.getCheckedItemPositions();
                ArrayList<Mark> selectedMarkData = new ArrayList<Mark>();

                for (int i = 0; i < markListView.getCount(); i++) {
                    if (sparseBooleanArray.get(i)) {
                        selectedMarkData.add(markDataListAdapter.getItem(i));
                        ((ImageView) markListView.getChildAt(i).findViewById(R.id.imageViewListItemChecked)).setImageDrawable(getResources().getDrawable(R.drawable.checkbox_unchecked));
                    }
                }

                if (selectedMarkData.size() == 0) {
                    Toast.makeText(MainActivity.this, "No mark selected", Toast.LENGTH_SHORT).show();
                } else {
                    for (int y = 0; y < selectedMarkData.size(); y++) {
                        progressReportListAdapter.getItem(itemPosition).getMarkArrayList().remove(selectedMarkData.get(y));
                    }

                    markListView.clearChoices();
                    progressReportListAdapter.notifyDataSetChanged();
                    markDataListAdapter.notifyDataSetChanged();
                }

                break;
            case R.id.imageButtonExitInfoDialog:
                progressReportListAdapter.notifyDataSetChanged();
                alertDialogAllInfo.cancel();

                break;
            case R.id.buttonOkEnterMark:
                EditText editTextMarkDialog = (EditText) alertDialogEnterMarkView.findViewById(R.id.editTextMark);
                if (!editTextMarkDialog.getText().toString().isEmpty()) {
                    if (!editTextMarkDialog.getText().toString().equals("0")) {
                        progressReportListAdapter.getItem(itemPosition).getMarkArrayList().add(getMarkData(Integer.parseInt(((EditText) alertDialogEnterMarkView.findViewById(R.id.editTextMark)).getText().toString())));
                        progressReportListAdapter.notifyDataSetChanged();

                        if (alertDialogAllInfo != null) {
                            if (alertDialogAllInfo.isShowing()) {
                                markDataListAdapter.notifyDataSetChanged();
                            }
                        }

                        alertDialogEnterMark.dismiss();
                    } else {
                        Toast.makeText(MainActivity.this, "This is an incorrect mark", Toast.LENGTH_SHORT).show();
                    }
                } else {
                    Toast.makeText(MainActivity.this, "Enter mark", Toast.LENGTH_SHORT).show();
                }

                break;
            case R.id.buttonCancelEnterMark:
                alertDialogEnterMark.cancel();

                break;
        }
    }

    @Override
    protected Dialog onCreateDialog(int id) {
        switch (id) {
            case ALERT_DIALOG_ENTER_NAME:
                builderEnterName = new AlertDialog.Builder(this);
                builderEnterName.setView(alertDialogEnterNameView);
                alertDialogEnterName = builderEnterName.create();
                alertDialogEnterName.getWindow().setBackgroundDrawable(new ColorDrawable(Color.TRANSPARENT));

                alertDialog = alertDialogEnterName;

                break;
            case ALERT_DIALOG_ALL_INFO:
                builderAllInfo = new AlertDialog.Builder(this);
                builderAllInfo.setView(alertDialogAllInfoView);
                alertDialogAllInfo = builderAllInfo.create();
                alertDialogAllInfo.getWindow().setBackgroundDrawable(new ColorDrawable(Color.TRANSPARENT));

                alertDialog = alertDialogAllInfo;

                break;
            case ALERT_DIALOG_ENTER_MARK:
                builderEnterMark= new AlertDialog.Builder(this);
                builderEnterMark.setView(alertDialogEnterMarkView);
                alertDialogEnterMark = builderEnterMark.create();
                alertDialogEnterMark.getWindow().setBackgroundDrawable(new ColorDrawable(Color.TRANSPARENT));

                alertDialog = alertDialogEnterMark;

                break;
        }

        return alertDialog;
    }

    @Override
    protected void onPrepareDialog(int id, Dialog dialog) {
        super.onPrepareDialog(id, dialog);

        switch (id) {
            case ALERT_DIALOG_ALL_INFO:
                ((TextView) dialog.getWindow().findViewById(R.id.textViewFullName)).setText(progressReportListAdapter.getItem(itemPosition).getSurname() + " " + progressReportListAdapter.getItem(itemPosition).getName() + "\n" + progressReportListAdapter.getItem(itemPosition).getMiddleName());

                markData = new ArrayList<Mark>();
                markData = progressReportListAdapter.getItem(itemPosition).getMarkArrayList();
                markDataListAdapter = new MarkDataListAdapter(this, R.layout.mark_row_item, markData);
                markListView.setAdapter(markDataListAdapter);

                break;
        }
    }

    private ListItem getListItem(String name, String surname, String middleName, int mark) {
        ListItem newsItem = new ListItem();
        newsItem.setName(name);
        newsItem.setSurname(surname);
        newsItem.setMiddleName(middleName);
        ArrayList<Mark> markData = new ArrayList<Mark>();

        if (mark != -1) {
            markData.add(getMarkData(mark));
        }

        newsItem.setMarkArrayList(markData);

        return newsItem;
    }

    private void clearDialogField(EditText editText) {
        editText.setText("");
    }

    Mark getMarkData(int mark) {
        Calendar calendar = Calendar.getInstance();

        SimpleDateFormat dateFormatYear = new SimpleDateFormat("yyyy");
        SimpleDateFormat dateFormatMonth = new SimpleDateFormat("M");
        SimpleDateFormat dateFormatDate = new SimpleDateFormat("d");
        SimpleDateFormat dateFormatHour = new SimpleDateFormat("H");
        SimpleDateFormat dateFormatMinute = new SimpleDateFormat("m");
        SimpleDateFormat dateFormatSecond = new SimpleDateFormat("s");

        Mark newMark = new Mark();
        newMark.setMark(mark);
        newMark.setYear(dateFormatYear.format(calendar.getTime()));
        newMark.setMonth(dateFormatMonth.format(calendar.getTime()));
        newMark.setDate(dateFormatDate.format(calendar.getTime()));
        newMark.setHour(dateFormatHour.format(calendar.getTime()));
        newMark.setMinute(dateFormatMinute.format(calendar.getTime()));
        newMark.setSecond(dateFormatSecond.format(calendar.getTime()));

        return newMark;
    }

    @Override
    public void onCreateContextMenu(ContextMenu menu, View v, ContextMenu.ContextMenuInfo menuInfo) {
        super.onCreateContextMenu(menu, v, menuInfo);

        getMenuInflater().inflate(R.menu.menu_list_item, menu);
    }

    @Override
    public boolean onContextItemSelected(MenuItem item) {
        AdapterView.AdapterContextMenuInfo adapterContextMenuInfo;
        switch (item.getItemId()) {
            case R.id.addMark:
                adapterContextMenuInfo = (AdapterView.AdapterContextMenuInfo) item.getMenuInfo();
                itemPosition = adapterContextMenuInfo.position;
                showDialog(ALERT_DIALOG_ENTER_MARK);

                break;
            case R.id.allInfo:
                adapterContextMenuInfo = (AdapterView.AdapterContextMenuInfo) item.getMenuInfo();
                itemPosition = adapterContextMenuInfo.position;
                showDialog(ALERT_DIALOG_ALL_INFO);

                break;
        }

        return super.onContextItemSelected(item);
    }

    @Override
    public Object onRetainCustomNonConfigurationInstance() {
        return progressReportListAdapter;
    }

    @Override
    protected void onSaveInstanceState(Bundle outState) {
        super.onSaveInstanceState(outState);

        outState.putInt("itemPosition", itemPosition);
    }

    @Override
    protected void onRestoreInstanceState(Bundle savedInstanceState) {
        super.onRestoreInstanceState(savedInstanceState);

        itemPosition = savedInstanceState.getInt("itemPosition");
    }
}
