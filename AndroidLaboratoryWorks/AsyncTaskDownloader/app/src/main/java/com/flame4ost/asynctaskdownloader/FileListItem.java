package com.flame4ost.asynctaskdownloader;

/**
 * Created by gogulov on 25.11.2020.
 */

public class FileListItem {
    private String fileName;
    private int timeDownload, fileState;

    public String getFileName() {
        return fileName;
    }

    public void setFileName(String fileName) {
        this.fileName = fileName;
    }

    public int getTimeDownload() {
        return timeDownload;
    }

    public void setTimeDownload(int timeDownload) {
        this.timeDownload = timeDownload;
    }

    public int getFileState() {
        return fileState;
    }

    public void setFileState(int fileState) {
        this.fileState = fileState;
    }
}
