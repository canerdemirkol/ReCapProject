
using Core.DataAccess.EntityFreamwork;
using Core.DataAccess.RepoDb;
using Core.Extensions;
using Core.Utilities.Map.Google;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete.Succes;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using DataAccess.Concrete.RepoDb.DbConnection.SqlDatabases;
using Entities.Concrete;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class MapKeyRepository : EfEntityRepositoryBase<MAP_KEY, ProjectDbContext>, IMapKeyRepository
    {


        public QueryableRepositoryBase<KonumdanAdresDetay, ReCapDbConnectionFactory> mapKeyRepo = new QueryableRepositoryBase<KonumdanAdresDetay, ReCapDbConnectionFactory>();

        public MapKeyRepository(ProjectDbContext context) : base(context)
        {

        }

        public string getApiKey()
        {
            return GetList().FirstOrDefault().MAP_API_KEY;
        }





        public KonumdanAdresDetay konumdanAdresGetir(string lat, string lng)
        {
            if (lat == "0" && lng == "0")
            {
                KonumdanAdresDetay kad = new KonumdanAdresDetay();
                kad.ilKodu = 0;
                kad.ilAdi = "0";
                kad.ilceKodu = 0;
                kad.Ilce = "0";
                kad.mahalleKodu = 0;
                kad.Mahalle = "0";
                kad.csbmKodu = 0;
                kad.Cadde = "0";
                return kad;
            }
            KonumdanAdres konadres = new KonumdanAdres();
            Location latlng = new Location();
            latlng.lat = lat;
            latlng.lng = lng;
            Geocoding geo = new Geocoding(latlng);
            geo.GoogleKey = getApiKey();
            if (geo.GoogleKey == "" || geo.GoogleKey == null || geo.GoogleKey == "-")
            {
                KonumdanAdresDetay kad = new KonumdanAdresDetay();
                kad.ilKodu = 0;
                kad.ilAdi = "0";
                kad.ilceKodu = 0;
                kad.Ilce = "0";
                kad.mahalleKodu = 0;
                kad.Mahalle = "0";
                kad.csbmKodu = 0;
                kad.Cadde = "0";
                return kad;
            }
            else
            {
                ADDRESS yeniAdres = new ADDRESS();
                yeniAdres = geo.adresBul();
                konadres.Ulke = yeniAdres.country;
                konadres.Il = yeniAdres.province;
                konadres.Ilce = yeniAdres.district;
                konadres.Mahalle = yeniAdres.neighborhood;
                konadres.Cadde = yeniAdres.street;
                konadres.Acik_Adres = yeniAdres.formatted_address;
                return KonumAdresDetay(konadres);
            }

        }



        private KonumdanAdresDetay KonumAdresDetay(KonumdanAdres konadres)
        {
            KonumdanAdresDetay detay = new KonumdanAdresDetay();
            if (konadres.Cadde == null)
            {
                detay.ilKodu = 0;
                detay.ilAdi = "0";
                detay.ilceKodu = 0;
                detay.Ilce = "0";
                detay.mahalleKodu = 0;
                detay.Mahalle = "0";
                detay.csbmKodu = 0;
                detay.Cadde = "0";
                return detay;

            }

            string[] ayirCsbm = (konadres.Cadde).Split(' ');
            int csbmUzunluk = ayirCsbm.Length;
            string tekCsbm = "";
            string tipCsbm = "";
            if (konadres.Il == null && konadres.Ilce == null && konadres.Mahalle == null && konadres.Cadde == null)
            {
                detay.ilKodu = 0;
                detay.ilAdi = "0";
                detay.ilceKodu = 0;
                detay.Ilce = "0";
                detay.mahalleKodu = 0;
                detay.Mahalle = "0";
                detay.csbmKodu = 0;
                detay.Cadde = "0";
                return detay;
            }
            for (int i = 0; i < (csbmUzunluk - 1); i++)
            {
                if (csbmUzunluk == 2)
                {
                    tipCsbm += ayirCsbm[(csbmUzunluk - 1)];
                    tekCsbm += ayirCsbm[i];
                }
                else
                {
                    if (i == (csbmUzunluk - 2))
                    {
                        tipCsbm += ayirCsbm[(csbmUzunluk - 1)];
                    }
                    tekCsbm += ayirCsbm[i];
                    tekCsbm += " ";
                }

            }




            string postListProcNameText = @"[dbo].[KonumAdresKontrol]";

            var param = new
            {
                il = konadres.Il.ToUpper(new CultureInfo("tr-TR", false)),
                ilce = konadres.Ilce.ToUpper(new CultureInfo("tr-TR", false)),
                mahalle = konadres.Mahalle.ToUpper(new CultureInfo("tr-TR", false)),
                csbm = konadres.Cadde.ToUpper(new CultureInfo("tr-TR", false)),
                tekCsbm = tekCsbm.ToUpper(new CultureInfo("tr-TR", false)),
                tipCsbm = tipCsbm.ToUpper(new CultureInfo("tr-TR", false))
            };
            //     List<KonumdanAdresDetay> x= (List<KonumdanAdresDetay>)mapKeyRepo.GetByExecuteStoredProcedureQuery(postListProcNameText, param);

            return mapKeyRepo.GetByExecuteStoredProcedureSingle(postListProcNameText, param);



        }


    }
}
