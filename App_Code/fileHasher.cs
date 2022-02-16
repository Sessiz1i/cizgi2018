using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.IO;

namespace fileHashh{ }
public class fileHasher
{
    public static string GetMD5Hash(string filePath)
    {
        try
        {
            using (var stream = new BufferedStream(File.OpenRead(filePath), 1200000))
            {
                SHA256Managed sha = new SHA256Managed();
                byte[] checksum = sha.ComputeHash(stream);
                return BitConverter.ToString(checksum).Replace("-", String.Empty);
            }

        }
        catch (Exception ex)
        {

            return ex.ToString();
        }
    }


    public static string rndPassGenerator2(int passUzunluk, int specialChar)
    {
        string allowedChars = "";
        allowedChars = "a,b,c,d,e,f,g,h,i,j,k,l,m,n,o,p,q,r,s,t,u,v,w,x,y,z,";
        allowedChars += "A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z,";
        allowedChars += "1,2,3,4,5,6,7,8,9,0";
        if (specialChar == 1)
        {
            allowedChars += "!,@,#,$,%,&,?";
        }

        char[] sep = { ',' };
        string[] arr = allowedChars.Split(sep);
        string passwordString = "";
        string temp = "";
        Random rand = new Random();
        for (int i = 0; i < Convert.ToInt32(passUzunluk); i++)
        {
            temp = arr[rand.Next(0, arr.Length)];
            passwordString += temp;
        }
        return passwordString;
    }

    public static string rndPassGenerator(int passUzunluk, int specialChar)
    {
        string allowedChars = "";
        allowedChars = "1,2,3,4,5,6,7,8,9,0";
        if (specialChar == 1)
        {
            allowedChars += "!,@,#,$,%,&,?";
        }

        char[] sep = { ',' };
        string[] arr = allowedChars.Split(sep);
        string passwordString = "";
        string temp = "";
        Random rand = new Random();
        for (int i = 0; i < Convert.ToInt32(passUzunluk); i++)
        {
            temp = arr[rand.Next(0, arr.Length)];
            passwordString += temp;
        }
        return passwordString;
    }
}