package com.flame4ost.asynctaskdownloader;

import android.app.Activity;
import android.content.DialogInterface;
import android.content.Intent;
import android.graphics.Color;
import android.graphics.drawable.ColorDrawable;
import android.support.v4.app.DialogFragment;
import android.os.Bundle;
import android.support.annotation.Nullable;
import android.text.Editable;
import android.view.LayoutInflater;
import android.view.View;
import android.view.View.OnClickListener;
import android.view.ViewGroup;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Toast;

/**
 * Created by gogulov on 25.11.2020.
 */

public class DialogAddFile extends DialogFragment implements OnClickListener {
    public static final String FRAGMENT_TAG = "DialogAddFile";
    EditText editTextFileName, editTextTimeDownload;
    Button buttonOkAddFile, buttonCancelAddFile;
    String fileName = "", timeDownload = "";

    @Nullable
    @Override
    public View onCreateView(LayoutInflater inflater, @Nullable ViewGroup container, Bundle savedInstanceState) {
        View view = inflater.inflate(R.layout.dialog_add_file, null);
        editTextFileName = (EditText) view.findViewById(R.id.editTextFileName);
        editTextTimeDownload = (EditText) view.findViewById(R.id.editTextTimeDownload);
        buttonOkAddFile = (Button) view.findViewById(R.id.buttonOkAddFile);
        buttonCancelAddFile = (Button) view.findViewById(R.id.buttonCancelAddFile);

        buttonOkAddFile.setOnClickListener(this);
        buttonCancelAddFile.setOnClickListener(this);

        getDialog().getWindow().setBackgroundDrawable(new ColorDrawable(Color.TRANSPARENT));

        return view;
    }

    @Override
    public void onClick(View v) {
        switch (v.getId()) {
            case R.id.buttonOkAddFile:
                fileName = editTextFileName.getText().toString();
                timeDownload = editTextTimeDownload.getText().toString();

                if (!fileName.isEmpty() && !timeDownload.isEmpty()) {
                    if (timeDownload != "0") {
                        Bundle bundle = new Bundle();
                        bundle.putString("fileName", fileName);
                        bundle.putInt("timeDownload", Integer.parseInt(timeDownload));
                        Intent intent = new Intent().putExtras(bundle);

                        getTargetFragment().onActivityResult(getTargetRequestCode(), Activity.RESULT_OK, intent);
                        dismiss();
                    } else {
                        Toast.makeText(getContext(), "his is an incorrect timeDownload!", Toast.LENGTH_SHORT).show();
                    }
                } else if (fileName.isEmpty() || timeDownload.isEmpty()) {
                    if (fileName.isEmpty()) {
                        Toast.makeText(getContext(), "Enter file name!", Toast.LENGTH_SHORT).show();
                    } else {
                        Toast.makeText(getContext(), "Enter time download_file!", Toast.LENGTH_SHORT).show();
                    }
                }

                break;
            case R.id.buttonCancelAddFile:
                dismiss();

                break;
        }
    }
}
