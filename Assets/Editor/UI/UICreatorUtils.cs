using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class UICreatorUtils : MonoBehaviour
{
   public static void GenUICtrlile(string filePath,string className)
    {
        if(File.Exists(Application.dataPath + filePath + className + ".cs"))
        {
            return;
        }

        StreamWriter sw = null;
        sw = new StreamWriter(Application.dataPath + filePath + className + ".cs");
        sw.WriteLine("using UnityEngine;\nusing System.Collections;\nusing UnityEngine.UI;\nusing System.Collections.Generic;\n");

        sw.WriteLine("public class " + className + ": UICtrl \n { "+ " \n ");
        sw.WriteLine("\t" + "public override void Awake() \n\t{");
        sw.WriteLine("\t\t" + "base.Awake();" + "\t");
        sw.WriteLine("\t" + "}" + "\t");

        sw.WriteLine("\t" + "void Start() \n\t{");
        sw.WriteLine("\t" + "}" + "\t");
        sw.WriteLine("}");

        sw.Flush();
        sw.Close();
    }


}
