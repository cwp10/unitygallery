package com.empty.unityplugin;

import android.app.Activity;
import android.content.Intent;
import android.database.Cursor;
import android.net.Uri;
import android.os.Bundle;
import android.provider.MediaStore;

import com.unity3d.player.UnityPlayer;

public class Gallery extends Activity {
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        open();
    }

    private void open() {
        Intent intent = new Intent(Intent.ACTION_PICK, MediaStore.Images.Media.INTERNAL_CONTENT_URI);
        startActivityForResult(intent, 0);
    }

    @Override
    protected void onActivityResult(int requestCode, int resultCode, Intent data) {
        super.onActivityResult(requestCode, resultCode, data);

        if (requestCode == 0 && resultCode == RESULT_OK) {
            Uri path = data.getData();
            String changeUri = absPath(path);

            UnityPlayer.UnitySendMessage("AndroidPlugin", "GetImage", changeUri);
        }

        finish();
    }

    private String absPath(Uri uri) {
        String[] data = { MediaStore.Images.Media.DATA };
        Cursor cursor = managedQuery(uri, data, null, null, null);
        startManagingCursor(cursor);
        int columIndex = cursor.getColumnIndexOrThrow(MediaStore.Images.Media.DATA);
        cursor.moveToFirst();
        return cursor.getString(columIndex);
    }
}
