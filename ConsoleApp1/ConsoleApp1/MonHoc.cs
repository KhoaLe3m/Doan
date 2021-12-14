using System;
using System.Collections.Generic;
using System.Collections;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;

namespace DoAn
{
    public class MonHoc
    {
        private string ID;
        private string TenMon;
        private int SoTinChi;
        private string GiangVien;
        private DateTime TimeBatDau;
        private DateTime TimeKetThuc;
        private string NgayGioHoc;
        private string CoSo;
        public MonHoc(string ID, string TenMon, int SoTinChi, string GiangVien, DateTime TimeBatDau, DateTime TimeKetThuc, string NgayGioHoc, string CoSo)
            {
                this.ID = ID;
                this.TenMon = TenMon;
                this.SoTinChi = SoTinChi;
                this.GiangVien = GiangVien;
                this.TimeBatDau = TimeBatDau;
                this.TimeKetThuc = TimeKetThuc;
                this.NgayGioHoc = NgayGioHoc;
                this.CoSo = CoSo;
            }
        public MonHoc()
        {
            this.ID = "";
            this.TenMon = "";
            this.SoTinChi = 0;
            this.GiangVien = "";
            this.TimeBatDau = new DateTime();
            this.TimeKetThuc = new DateTime();
            this.NgayGioHoc = "";
            this.CoSo = "";
        }
            public string GetID()
            {
                return this.ID;
            }
        public string GetTenMon()
        {
            return this.TenMon;
        }
        public int GetSoTinChi()
        {
            return this.SoTinChi;
        }
        public string GetGiangVien()
        {
            return this.GiangVien;
        }
        public DateTime GetTimeBatDau()
        {
            return this.TimeBatDau;
        }
        public DateTime GetTimeKetThuc()
        {
            return this.TimeKetThuc;
        }
        public string GetNgayGioHoc()
        {
            return this.NgayGioHoc;
        }
        public string GetCoSo()
        {
            return this.CoSo;
        }
        public override string ToString()
        {
            return "MonHoc(" + ID + "," + TenMon + "," + SoTinChi + "," + GiangVien + "," + TimeBatDau.ToShortDateString() + "," + TimeKetThuc.ToShortDateString() + "," + NgayGioHoc + "," + CoSo + ")";
        }
    }
}