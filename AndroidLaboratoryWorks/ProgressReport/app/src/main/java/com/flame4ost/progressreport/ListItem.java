package com.flame4ost.progressreport;

import java.util.ArrayList;
import java.util.Date;

/**
 * Created by gogulov on 20.10.2020.
 */

public class ListItem {
    String name, surname, middleName;
    ArrayList<Mark> markArrayList;

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public String getSurname() {
        return surname;
    }

    public void setSurname(String surname) {
        this.surname = surname;
    }

    public String getMiddleName() {
        return middleName;
    }

    public void setMiddleName(String middleName) {
        this.middleName = middleName;
    }

    public ArrayList<Mark> getMarkArrayList() {
        return markArrayList;
    }

    public void setMarkArrayList(ArrayList<Mark> markArrayList) {
        this.markArrayList = markArrayList;
    }
}
