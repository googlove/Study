package com.example.vulama.webbrowser;

//class which is used for operation of custom list adapter named "BookmarkListAdapter", used also for History view
// because History also needs two string values to be showed in listView


public class Bookmark {

    //declaration of variables needed for object created form this class

    private String name;
    private String address;

    //constructor that sets up values if they are given at the initialization of object derived from this class

    public Bookmark(String name, String address) {
        this.name = name;
        this.address = address;
    }

    //methods that set or get vaules for specific variable

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public String getAddress() {
        return address;
    }

    public void setAddress(String address) {
        this.address = address;
    }
}
