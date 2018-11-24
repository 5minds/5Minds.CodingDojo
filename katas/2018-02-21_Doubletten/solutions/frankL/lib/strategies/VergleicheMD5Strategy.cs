using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using common.interfaces;
using lib.models;

namespace lib.strategies
{
    public class VergleicheMD5Strategy : VergleicheStrategyBase, IVergleichStrategy, IDisposable
    {
        private MD5 _md5Provider;

        public VergleicheMD5Strategy(IDateiErmittler dateiErmittler) : base(dateiErmittler)
        {
            _md5Provider = MD5.Create();
        }

        public void Dispose()
        {
            _md5Provider?.Dispose();
        }

        public IVergleichToken ErstelleToken(string dateiPfad)
        {
            var token = new VergleichToken()
            {
                Key = GetMd5Hash(DateiErmittler.LeseInhalt(dateiPfad)),
            };

            return token;
        }

        private string GetMd5Hash(byte[] inhalt)
        {
            if (inhalt == null)
            {
                return string.Empty;
            }

            var result = _md5Provider.ComputeHash(inhalt);
            
            return BitConverter.ToString(result).Replace("-","");
        }
    }
}