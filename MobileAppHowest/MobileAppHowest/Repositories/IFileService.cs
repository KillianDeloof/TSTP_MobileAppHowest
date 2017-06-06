using System;
using System.Collections.Generic;
using System.Text;
//remove this file if mediapicker works whitout chomado's code
namespace MobileAppHowest.Repositories
{
    // ファイル名から path を返すっていうインターフェイス
    //returns filename from path?
    public interface IFileService
    {
        // OSごとに異なるdatabaseのファイルをどこに作るかっていうファイルパス
        //????
        string GetLocalFilePath(string fileName);
    }
}
