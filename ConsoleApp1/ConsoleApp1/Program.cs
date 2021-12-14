using System;
using System.Collections.Generic;
using System.Collections;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using System.Text;
using System.Globalization;

namespace DoAn
{
    class Program
    {
        static Node2 FindGVMH(DoubleLinkedList Subjects, string tengv, string tenmh)//dư xóa đi 
        {
            Node2 current = new Node2();
            current = Subjects.header;
            while (current.element.GetGiangVien() != tengv || current.element.GetTenMon() != tenmh)
            {
                current = current.flink;
            }
            return current;
        }
        static Node2 FindID(DoubleLinkedList Subjects, string ID)// đơn giản thôi duyệt cái DSLK nhập vào nếu = thì return cái current
        {
            Node2 current = new Node2();
            current = Subjects.header;
            while (current.element.GetID() != ID)
            {
                current = current.flink;
            }
            return current;
        }
        static void FindName(DoubleLinkedList Subjects, string TenMH, DoubleLinkedList TenMon)
        {
            Node2 current = new Node2();
            current = Subjects.header;
            int j = 0;
            while (current.flink != null)
            {
                current = current.flink;
                if (current.element.GetTenMon().ToLower() == TenMH)
                {
                    j++;// tìm thấy thì tăng i lên 
                    TenMon.AddLast(current.element);// timf thấy thì thêm vào cái DSLK Tenmon  
                }
            }
            if (j == 0)// i không thay đổi thì in ra k có .
            {
                Console.WriteLine("\n\tKhông tồn tại môn học có tên {0}", TenMH);
            }
        }
        static void FindGV(DoubleLinkedList Subjects, string tengv, DoubleLinkedList GV)
        {//tương tự tìm thấy môn nào có giảng viên mình muốn thì thêm vào DSLK GV 
            Node2 current = new Node2();
            current = Subjects.header;
            while (current.flink != null)
            {
                current = current.flink;
                if (current.element.GetGiangVien().ToLower() == tengv)
                {
                    GV.AddLast(current.element);
                }
            }
        }
        static void FindCS(DoubleLinkedList Subjects, string tencs, DoubleLinkedList CS)
        {//TƯƠNG TỰ TRÊN
            Node2 current = new Node2();
            current = Subjects.header;
            while (current.flink != null)
            {
                current = current.flink;
                if (current.element.GetCoSo().ToLower().Contains(tencs))
                {
                    CS.AddLast(current.element);
                }
            }
        }
        static void FindTS(DoubleLinkedList Subjects, DateTime a, DateTime b, DoubleLinkedList TS)
        {//DUYỆT CÁI dslkd nếu có môn nào bắt đầu và kết thúc nằm trong khoảng a,b thì thêm vào TS 
            Node2 current = new Node2();
            current = Subjects.header;
            while (current.flink != null)
            {
                current = current.flink;
                if (current.element.GetTimeBatDau() >= a && current.element.GetTimeKetThuc() <= b)
                {
                    TS.AddLast(current.element);
                }
            }
        }   
        static void Swap(ref MonHoc a, ref MonHoc b)
        {//đổi dữ liệu 2 node
            MonHoc temp = new MonHoc();
            temp = a;
            a = b;
            b = temp;
        }
        static void SortTimeStart(DoubleLinkedList a)
        {
            Node2 current = new Node2();
            for (int i = 0; i < a.GetCount() - 1; i++)//lặp lại count -1 lần 
            {
                current = a.header.flink;
                while (current.flink != null)
                {
                    DateTime d1 = current.element.GetTimeBatDau();
                    DateTime d2 = current.flink.element.GetTimeBatDau();
                    if (DateTime.Compare(d1, d2) > 0)// kiểm tra nếu như d2 bắt đầu sớm hơn d1 thì đổi chỗ 
                    {
                        Swap(ref current.element, ref current.flink.element);
                    }
                    current = current.flink;//giống như sắp xếp 1 mảng cứ so sánh 2 phần tử liên tiếp là sẽ xong
                }
            }
        }
        static void SortTimeEnd(DoubleLinkedList a)
        {//tương tự trên 
            Node2 current = new Node2();
            for (int i = 0; i < a.GetCount() - 1; i++)
            {
                current = a.header;
                current = current.flink;
                while (current.flink != null)
                {
                    DateTime d1 = current.element.GetTimeKetThuc();
                    DateTime d2 = current.flink.element.GetTimeKetThuc();
                    if (DateTime.Compare(d1, d2) < 0)
                    {
                        Swap(ref current.element, ref current.flink.element);
                    }
                    current = current.flink;
                }
            }
        }
        static bool CheckTime(DateTime a, DateTime b, DateTime c, DateTime d)
        {
            if (b < c || d < a) { return true; }//true : không liên quan gì đến nhau 
            else return false;// false : trùng time     
        }
        static void Add(MonHoc MonHoc, DoubleLinkedList a)
        {
            int temp = 0;
            Node2 current = new Node2();
            current = a.header;
            while (current.flink != null)
            {
                current = current.flink;
                if (MonHoc == current.element)// nếu môn học đã có trong dslk thì biến temp tăng lên 
                {
                    temp++;
                }
            }
            if (temp == 0)
            {
                a.AddLast(MonHoc);
                Console.WriteLine("\n\tMôn học đã được thêm thành công!");
            }
            else
            {
                Console.WriteLine("\n\tMôn học đã tồn tại trong danh sách! ");
            }
        }
        static void AddSingle(MonHoc monhoc, ArrayList arr)
        {// thêm môn học vào mảng giống như trên thêm kiểm tra nếu tôtnf tại thì k thêm 
            int temp = 0;
            for (int i = 0; i < arr.Count; i++)
            {
                if (monhoc == arr[i])
                {
                    temp++;
                }
            }
            if (temp == 0)
            {
                arr.Add(monhoc);
            }
        }
        static void CheckList(DoubleLinkedList a)
        {
            ArrayList arr = new ArrayList();
            ArrayList arr2 = new ArrayList();
            Node2 current = new Node2();
            current = a.header;
            while (current.flink != null)
            {
                current = current.flink;
                arr.Add(current.element);//thêm tất cả các môn vào arr
            }
            int temp = 0;
            for (int i = 0; i < arr.Count; i++)
            {
                for (int j = i; j < arr.Count; j++)//kiem tra 1 phần tử với các phần tử còn lại thử sửa j =i xem chạy dc  k 
                {
                    MonHoc m1 = new MonHoc();
                    m1 = (MonHoc)arr[i];
                    MonHoc m2 = new MonHoc();
                    m2 = (MonHoc)arr[j];
                    if (m1 != m2)
                    {
                        if (CheckTime(m1.GetTimeBatDau(), m1.GetTimeKetThuc(), m2.GetTimeBatDau(), m2.GetTimeKetThuc()) || m1.GetNgayGioHoc() != m2.GetNgayGioHoc())
                        {
                            //khong trung
                        }
                        else
                        {
                            temp++;
                            AddSingle(m1, arr2);
                            AddSingle(m2, arr2);
                            //trung
                        }
                    }
                }
            }
            if (temp == 0)
            {
                Console.Write("\n\tKết qủa kiểm tra: Ok");
            }
            else
            {
                Console.WriteLine("\n\tTrùng Lịch: ");
                Console.WriteLine();
                foreach (var val in arr2)
                {
                    Console.WriteLine("\n\t{0}", val);
                }
            }
        }
        static int TinhSoTien(DoubleLinkedList Subjects)
        {
            int tinchi = 0;
            int SoTien = 650000;
            Node2 current = Subjects.header;
            while (current != null)
            {
                tinchi += current.element.GetSoTinChi();//duyệt dslkd cộng tín chỉ lại * giá tiền 
                current = current.flink;
            }
            return SoTien * tinchi;
        }
        static void Start()// làm màu 
        { 
            Console.Clear();
            Console.WriteLine("\n\n\t\t\t\tĐỒ ÁN CẤU TRÚC DỮ LIỆU VÀ GIẢI THUẬT");
            Console.WriteLine("\n\t\t\t Đề:Xây Dưng DSLKD, Class Môn Học Và Các Chức Năng");
            Console.WriteLine("\n\t\t\t****************************************************");
        }
        static void Main(string[] args)
        {
            Console.InputEncoding = System.Text.Encoding.Unicode;
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Console.Clear();
            DoubleLinkedList Subjects = new DoubleLinkedList();
            DoubleLinkedList MyChoose = new DoubleLinkedList();
            Subjects.Insert(new MonHoc("MH01", "Cơ Sở Lập Trình", 3, "Đặng Ngọc Hoàng Thành", new DateTime(2021, 8, 9), new DateTime(2021, 10, 4), "Sáng Thứ 2", "Cở Sở N1"), "MH00");
            Subjects.Insert(new MonHoc("MH02", "Cấu Trúc Dữ Liệu Và Giải Thuật", 3, "Đặng Ngọc Hoàng Thành", new DateTime(2021, 10, 18), new DateTime(2021, 12, 1), "Chiều Thứ 4", "Cơ Sở N1"), "MH01");
            Subjects.Insert(new MonHoc("MH03", "Toán Dành Cho Tin Học", 3, "Huỳnh Văn Đức", new DateTime(2021, 10, 15), new DateTime(2021, 12, 3), "Chiều Thứ 6", "Cơ Sở N1"), "MH02");
            Subjects.Insert(new MonHoc("MH04", "Tư Tưởng Hồ Chí Minh", 2, "Đỗ Minh Tứ", new DateTime(2021, 9, 22), new DateTime(2021, 10, 27), "Sáng Thứ 4", "Cơ Sở N1"), "MH03");
            Subjects.Insert(new MonHoc("MH05", "Tiếng Anh P3", 4, "Nguyễn Tấn Quang", new DateTime(2021, 8, 12), new DateTime(2021, 11, 4), "Chiều Thứ 5", "Cơ Sở N1"), "MH04");
            Subjects.Insert(new MonHoc("MH06", "Mạng Máy Tính", 2, "Trần Lê Phúc Thịnh", new DateTime(2021, 10, 2), new DateTime(2021, 12, 4), "Sáng Thứ 6", "Cơ Sở N1"), "MH05");
            Subjects.Insert(new MonHoc("MH07", "Tiếng Anh P3", 4, "Trần Mai chi", new DateTime(2021, 8, 12), new DateTime(2021, 11, 24), "Chiều Thứ 4", "Cơ Sở B2"), "MH06");
            Subjects.Insert(new MonHoc("MH08", "Phát Triển Ứng Dụng Desktop", 3, "Phan Hiền", new DateTime(2022, 3, 24), new DateTime(2022, 5, 19), "Chiều Thứ 5", "Cơ Sở B2"), "MH07");
            Subjects.Insert(new MonHoc("MH09", "Lịch Sử Đảng Cộng Sản Việt Nam", 2, "Hoàng Xuân Sơn", new DateTime(2022, 3, 5), new DateTime(2022, 4, 9), "Chiều Thứ 7", "Cơ Sở N2"), "MH08");
            Subjects.Insert(new MonHoc("MH10", "Lịch Sử Đảng Cộng Sản Việt Nam", 2, "Đỗ Minh Tứ", new DateTime(2022, 3, 5), new DateTime(2022, 4, 9), "Sáng Thứ 6", "Cơ Sở N2"), "MH09");
            Subjects.Insert(new MonHoc("MH11", "Tiếng Anh P3", 4, "Hoàng Anh Thư", new DateTime(2022, 1, 17), new DateTime(2022, 4, 25), "Chiều Thứ 2", "Cơ Sở N2"), "MH10");
            Subjects.Insert(new MonHoc("MH12", "Phân Tích Thiết Kế Hệ Thống", 3, "Huỳnh Văn Đức", new DateTime(2022, 3, 22), new DateTime(2022, 5, 17), "Sáng Thứ 3", "Cơ Sở B2"), "MH11");
            Subjects.Insert(new MonHoc("MH13", "Lập Trình Hướng Đối Tượng", 3, "Đặng Ngọc Hoàng Thành", new DateTime(2022, 1, 4), new DateTime(2022, 3, 15), "Sáng Thứ 3", "Cơ Sở B2"), "MH12");
            Subjects.Insert(new MonHoc("MH14", "Cơ Sở Dữ Liệu", 3, "Bùi Xuân Huy", new DateTime(2022, 1, 4), new DateTime(2022, 3, 15), "Sáng Thứ 3", "Cơ Sở B2"), "MH13");
            Subjects.Insert(new MonHoc("MH15", "Cơ Sở Lập Trình", 3, "Bùi Xuân Huy", new DateTime(2021, 8, 9), new DateTime(2021, 10, 4), "Sáng thứ 3", "Cơ Sở B2"), "MH14");
            while (true)
            {
                Start();
                Console.WriteLine("\n\t1.In Danh Sách Các Môn Học");
                Console.WriteLine("\n\t2.Thêm Môn Học");
                Console.WriteLine("\n\t3.Sắp Xếp Các Môn Học Theo Thời Gian Bắt Đầu Học Sớm Hơn");
                Console.WriteLine("\n\t4.Sắp Xếp Các Môn Học Theo Thời Gian Kết Thúc Học Muộn Hơn");
                Console.WriteLine("\n\t5.Tìm Kiếm Theo ID môn học");
                Console.WriteLine("\n\t6.Tìm Kiếm Theo Tên Môn Học");
                Console.WriteLine("\n\t7.Tìm Kiếm Theo Tên Giảng Viên");
                Console.WriteLine("\n\t8.Tìm Kiếm Theo Cơ Sở Học");
                Console.WriteLine("\n\t9.Tìm Kiếm Những Môn Học Diễn Ra Trong Một Mốc Thời Gian");
                Console.WriteLine("\n\t10.Xóa Và Kiểm Tra Sự Trùng Lặp Ngày Giờ Học Trong Danh Sách");
                Console.WriteLine("\n\t11.Tính Tiền");
                Console.WriteLine("\n\t0.Thoát Khỏi Chương Trình");
                Console.Write("\n\tVui Lòng Nhập Lựa Chọn Của Bạn! ");
                int luachon = int.Parse(Console.ReadLine());
                switch (luachon)
                {
                    case 1:
                        Start();
                        Console.WriteLine("\n\n\tDanh Sách các môn học: ");
                        Subjects.Print();// đơn giản chỉ là in cái danh sách thôi 
                        Console.ReadKey();
                        break; //xong
                    case 2:
                        {
                            Start();
                            Console.WriteLine();
                            Subjects.Print();
                        tem:
                            Console.Write("\n\tNhập ID môn học mà bạn muốn chọn: ");
                            string id = Console.ReadLine();
                            id = id.ToUpper();
                            bool check = false;
                            MonHoc sv;
                            Node2 current = new Node2();
                            current = Subjects.header;
                            while (current != null)
                            {
                                if (current.element.GetID() == id)
                                {
                                    check = true;
                                }
                                current = current.flink;
                            }
                            if (check)
                            {
                                sv = FindID(Subjects, id).element;
                            }
                            else
                            {
                                Console.WriteLine("\n\tID = " + id + " Không tồn tại trong DLKD");
                                goto tem;
                            }
                            Add(FindID(Subjects, id).element, MyChoose);
                            Console.ReadKey();
                            break;//xong
                        }
                    case 3:
                        {
                            Start();
                            SortTimeStart(Subjects);
                            System.Console.WriteLine("\n\tDanh sách các môn học sau khi sắp xếp theo thời gian bắt đầu sớm hơn: ");
                            Console.WriteLine();
                            Subjects.Print();
                            Console.Write("\n\tNhập phím 1 để thêm môn học vào danh sách lựa chọn hoặc 0 để quay lại Menu: ");
                            int a = int.Parse(Console.ReadLine());
                            switch (a)
                            {
                                case 1:
                                    Console.Write("\n\tNhập ID môn học mà bạn muốn chọn: ");
                                    string id = Console.ReadLine();
                                    id = id.ToUpper();
                                    Add(FindID(Subjects, id).element, MyChoose);
                                    Console.ReadKey();
                                    break;
                                case 0:
                                    break;
                            }
                            break;//xong
                        }
                    case 4:
                        {
                            Start();
                            SortTimeEnd(Subjects);
                            System.Console.WriteLine("\n\tDanh sách các môn học sau khi sắp xếp theo thời gian kết thúc muộn hơn: ");
                            Console.WriteLine();
                            Subjects.Print();
                            Console.Write("\n\tNhập phím 1 để thêm môn học vào danh sách lựa chọn hoặc 0 để quay lại Menu: ");
                            int a = int.Parse(Console.ReadLine());
                            switch (a)
                            {
                                case 1:
                                    Console.Write("\n\tNhập ID môn học mà bạn muốn chọn: ");
                                    string id = Console.ReadLine();
                                    id = id.ToUpper();
                                    Add(FindID(Subjects, id).element, MyChoose);
                                    Console.ReadKey();
                                    break;
                                case 0:
                                    break;
                            }
                            break;//xong
                        }
                    case 5:
                        {
                            Start();
                            Console.Write("\n\tNhập ID cần tìm: ");
                            string ID = Console.ReadLine();
                            ID = ID.ToUpper();
                            MonHoc MH = FindID(Subjects, ID).element;
                            Console.WriteLine("\n\t{0}", MH);
                            Console.Write("\n\tNhập phím 1 để thêm môn học vào danh sách lựa chọn hoặc 0 để quay lại Menu: ");
                            int a = int.Parse(Console.ReadLine());
                            switch (a)
                            {
                                case 1:
                                    Add(MH, MyChoose);
                                    Console.ReadKey();
                                    break;
                                case 0:
                                    break;
                            }
                            break;//xong
                        }
                    case 6:
                        {
                            Start();
                            DoubleLinkedList TenMon = new DoubleLinkedList();
                            Console.Write("\n\tNhập Tên Môn Học cần tìm: ");
                            string TenMH = Console.ReadLine();
                            TenMH = TenMH.ToLower();
                            FindName(Subjects, TenMH, TenMon);
                            TenMon.Print();
                            if (TenMon.GetCount() != 0)
                            {
                                Console.Write("\n\tNhập phím 1 để thêm môn học vào danh sách lựa chọn hoặc 0 để quay lại Menu: ");
                                int a = int.Parse(Console.ReadLine());
                                switch (a)
                                {
                                    case 1:
                                        Console.Write("\n\tNhập ID môn học mà bạn muốn chọn: ");
                                        string id = Console.ReadLine();
                                        id = id.ToUpper();
                                        Add(FindID(Subjects, id).element, MyChoose);
                                        Console.ReadKey();
                                        break;
                                    case 0:
                                        break;
                                }
                            }
                            break;//xong
                        }
                    case 7:
                        {
                            Start();
                            DoubleLinkedList TenGV = new DoubleLinkedList();
                            Console.Write("\n\tNhập Tên Giảng Viên cần tìm: ");
                            string Tengv = Console.ReadLine();
                            Tengv = Tengv.ToLower();
                            FindGV(Subjects, Tengv, TenGV);
                            TenGV.Print();
                            Console.Write("\n\tNhập phím 1 để thêm môn học vào danh sách lựa chọn hoặc 0 để quay lại Menu: ");
                            int a = int.Parse(Console.ReadLine());
                            switch (a)
                            {
                                case 1:
                                    Console.Write("\n\tNhập ID môn học mà bạn muốn chọn: ");
                                    string id = Console.ReadLine();
                                    id = id.ToUpper();
                                    Add(FindID(Subjects, id).element, MyChoose);
                                    Console.ReadKey();
                                    break;
                                case 0:
                                    break;
                            }
                            break;//xong
                        }
                    case 8:
                        {
                            Start();
                            DoubleLinkedList CS = new DoubleLinkedList();
                            Console.Write("\n\tNhập Cơ Sở cần tìm: ");
                            string cs = Console.ReadLine();
                            cs = cs.ToLower();
                            FindCS(Subjects, cs, CS);
                            CS.Print();
                            Console.Write("\n\tNhập phím 1 để thêm môn học vào danh sách lựa chọn hoặc 0 để quay lại Menu: ");
                            int a = int.Parse(Console.ReadLine());
                            switch (a)
                            {
                                case 1:
                                    Console.Write("\n\tNhập ID môn học mà bạn muốn chọn: ");
                                    string id = Console.ReadLine();
                                    id = id.ToUpper();
                                    Add(FindID(Subjects, id).element, MyChoose);
                                    Console.ReadKey();
                                    break;
                                case 0:
                                    break;
                            }
                            break;//xong
                        }
                    case 9:
                        {
                            Start();
                            DoubleLinkedList TS = new DoubleLinkedList();
                            Console.WriteLine("Nhập Thời gian bắt đầu và kết thúc:");
                            DateTime d1 = Convert.ToDateTime(Console.ReadLine());
                            DateTime d2 = Convert.ToDateTime(Console.ReadLine());
                            Console.WriteLine("\n\tNhững môn học bắt đầu sau ngày {0} và kết thúc trước ngày {1} là: ", d1, d2);
                            FindTS(Subjects, d1, d2, TS);
                            TS.Print();
                            Console.WriteLine("\n\tNhập phím 1 để thêm môn học vào danh sách lựa chọn hoặc 0 để quay lại Menu: ");
                            int a = int.Parse(Console.ReadLine());
                            switch (a)
                            {
                                case 1:
                                    Console.Write("\n\tNhập ID môn học mà bạn muốn chọn: ");
                                    string id = Console.ReadLine();
                                    id = id.ToUpper();
                                    Add(FindID(Subjects, id).element, MyChoose);
                                    Console.ReadKey();
                                    break;
                                case 0:
                                    break;
                            }
                            break;//xong
                        }
                    case 10:
                        {
                            Start();
                            Console.WriteLine("\n\tDanh sách các môn học đã chọn: ");
                            MyChoose.Print();
                            CheckList(MyChoose);
                            while (true)
                            {
                                Console.Write("\n\tNhập id môn học muốn xóa hoặc phím 0 để về Menu: ");
                                string RemoveId = Console.ReadLine();
                                switch (RemoveId)
                                {
                                    case "0":
                                        goto nhan;
                                    default:
                                        RemoveId = RemoveId.ToUpper();
                                        MyChoose.Remove(RemoveId);
                                        Console.WriteLine("\n\tDanh sách các môn học sau khi xóa: ");
                                        Console.WriteLine();
                                        MyChoose.Print();
                                        Console.WriteLine("\n\tKết quả kiểm tra sau khi xóa một số môn học bị trùng: ");
                                        CheckList(MyChoose);
                                        Console.ReadKey();
                                        break;
                                }
                            }
                        nhan:
                            break;
                        }
                    case 11:
                        {
                            Start();
                            Console.WriteLine("\n\tBạn đã chọn {0} môn học: ", MyChoose.GetCount());
                            MyChoose.Print();
                            Console.WriteLine("\n\tĐơn giá: 650,000vnđ/1 tín chỉ ");
                            Console.Write("\n\tSố tiền của các môn đã đăng ký học phần là {0} ", string.Format("{0:#,##0 vnđ}", TinhSoTien(MyChoose)));
                            Console.ReadKey();
                            break;//xong
                        }
                    case 0:
                        {
                            return;
                        }
                }
            }
        }
    }
}
