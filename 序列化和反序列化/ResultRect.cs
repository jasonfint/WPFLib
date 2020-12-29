using ProtoBuf;
using System;
using System.Windows;
using static 序列化和反序列化.RectTypeClass;

namespace 序列化和反序列化
{
    [Serializable]
    [ProtoContract]
    public class ResultRect
    {
        [ProtoMember(1)]
        public string Name { get; set; } = "Chip-01233-0605()";
        [ProtoMember(2)]
        public ResultType RType { get; set; } = ResultType.开焊;
        [ProtoMember(3)]
        public int X { get; set; } = 100;
        [ProtoMember(4)]
        public int Y { get; set; } = 200;
        [ProtoMember(5)]
        public int Width { get; set; } = 800;
        [ProtoMember(6)]
        public int Height { get; set; } = 900;
        [ProtoMember(7)]
        public int RotCenterX = 10;
        [ProtoMember(8)]
        public int RotCenterY = 20;
        [ProtoMember(9)]
        public int TotalRotAngle { get; set; } = 100;
        [ProtoMember(10)]
        public int Angle { get; set; } = 90;
        [ProtoMember(11)]
        public int subBoardId { get; set; } = 0;
        [ProtoMember(12)]
        public int SequenceID { get; set; } = 3;
        [ProtoMember(13)]
        public int SelectColors { get; set; } = 1;
        [ProtoMember(14)]
        public int ImageBright { get; set; } = 1;
        [ProtoMember(15)]
        public int ImageKey { get; set; } = 9;
        ////[ProtoMember(15)]
        //public Point SearchShift { get; set; } = new Point(100, 5120);
        ////[ProtoMember(16)]
        //public Point MarkShift { get; set; } = new Point(70, 5120);
        ////[ProtoMember(17)]
        //public Point CPUPinStaShfit { get; set; } = new Point(700, 5120);
        [ProtoMember(18)]
        public double CPUPinStaAnglex { get; set; } = 14.5;
        [ProtoMember(19)]
        public double CPUPinStaAngler { get; set; } = 14245.5;
        [ProtoMember(20)]
        public int PinXShfit { get; set; } = 14245;
        [ProtoMember(21)]
        public int PinYShfit { get; set; } = 145;
        //public override string ToString()
        //{
        //    return $"{Name},{RType},{X},{Y},{Width},{Height},{RotCenter.X},{RotCenter.Y},{TotalRotAngle},{Angle},{subBoardId},{SequenceID},{SelectColors},{ImageBright},{ImageKey},{SearchShift.X},{SearchShift.Y},{MarkShift.X},{MarkShift.Y},{CPUPinStaShfit.X},{CPUPinStaShfit.Y},{CPUPinStaAnglex},{CPUPinStaAngler},{PinXShfit},{PinYShfit}";
        //}
    }

}
