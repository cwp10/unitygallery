package com.empty.unityplugin;

import android.app.Activity;
import android.content.Context;
import android.content.Intent;

public class Media {
    private static Media _instance = null;
    public Context context = null;
    public static Media instance() {
        if (_instance == null) {
            _instance = new Media();
        }
        return _instance;
    }

    private void setContext(Context context) {
        this.context = context;
    }

    private static void showGallery(Activity activity) {
        Intent intent = new Intent(activity, Gallery.class);
        activity.startActivity(intent);
    }
}
