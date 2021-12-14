using System;
using System.Collections.Generic;
using System.Collections;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn
{
    public class Node2
    {
        public MonHoc element;
        public Node2 flink, blink;
        public Node2()
        {
            element = null;
            flink = blink = null;
        }
        public Node2(MonHoc element)
        {
            this.element = element;
            flink = blink = null;
        }
    }

}