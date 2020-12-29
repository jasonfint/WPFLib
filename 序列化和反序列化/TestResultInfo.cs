using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Windows;

using static 序列化和反序列化.RectTypeClass;

namespace 序列化和反序列化
{
    [Serializable]
    [ProtoContract]
    public class TestResultInfo
    {
        public TestResultInfo()
        { }
        [ProtoMember(22)]
        public ResultRect ResultRectInfo=new ResultRect();
        [ProtoMember(23)]
        public string Name="测试";
        [ProtoMember(24)]
        public ResultType RType=ResultType.错件;
        [ProtoMember(25)]
        public int x=32;
        [ProtoMember(26)]
        public int Y=90;
        [ProtoMember(27)]
        public int width=879;
        [ProtoMember(28)]
        public int Height=432;
        [ProtoMember(29)]
        public int RotCenterX = 10;
        [ProtoMember(30)]
        public int RotCenterY = 20;        
        [ProtoMember(31)]
        public int Angle=90;
        [ProtoMember(32)]
        public int subBoardId=342;
        [ProtoMember(33)]
        public int SequenceID=432;
        [ProtoMember(34)]
        public int SelectColors=432;
        [ProtoMember(35)]
        public int ImageBright=6;
        [ProtoMember(36)]
        public int ImageKey=56;   
        [ProtoMember(37)]
        public int SearchShiftx = 10;
        [ProtoMember(38)]
        public int SearchShiftY = 20;
        [ProtoMember(39)]
        public int MarkShiftX = 101;
        [ProtoMember(40)]
        public int MarkShiftY = 510;       
        [ProtoMember(41)]
        public int CPUPinStaShfitX = 101;
        [ProtoMember(42)]
        public int CPUPinStaShfitY = 5101;
        [ProtoMember(43)]
        public double CPUPinStaAngleX=67.2;
        [ProtoMember(44)]
        public double CPUPinStaAngleY=45.0;
        [ProtoMember(45)]
        public int PinXShfit=6;
        [ProtoMember(46)]
        public int PinYShfit=8;
        [ProtoMember(47)]
        public string Item="测试呀12";
        [ProtoMember(48)]
        public string Target="目标呀";
        [ProtoMember(49)]
        public string Value="这是";
        [ProtoMember(50)]
        public ResultType Result=ResultType.露铜;
        [ProtoMember(51)]
        public int FovId=45;
        [ProtoMember(52)]
        public string TestTime=DateTime.Now.ToLongDateString();
        [ProtoMember(53)]
        public int ID=5423;
        [ProtoMember(54)]
        public string Model="模型1";
        [ProtoMember(55)]
        public string Code="编码";
        [ProtoMember(56)]
        public string Package="封装";
        [ProtoMember(57)]
        public string MountingName="Mo";
        [ProtoMember(58)]
        public string ComponentBarcode="232423";
        [ProtoMember(59)]
        public int ConfirmTimes=897;
        [ProtoMember(60)]
        public ResultType ConfirmResult=ResultType.开焊;
        [ProtoMember(61)]
        public int DiffX { get; set; } = 234;
        [ProtoMember(62)]
        public int DiffY { get; set; } = 234;
        [ProtoMember(63)]
        public string Defectcode="212";
        [ProtoMember(64)]
        public string UserDefindConfirm="NG";
        [ProtoMember(65)]
        public bool CompelNG=true;
        [ProtoMember(66)]
        public string TargetResultType="目标结果";
        [ProtoMember(67)]
        public List<TestResultInfo> Subs = new List<TestResultInfo>();
        [ProtoMember(68)]
        public int TotalRotAngle = 270;
        //public override string ToString()
        //{
        //    //return $"{ResultRectInfo.ToString()}{Name},{RType},{x},{Y},{width},{Height},{RotCenter.X},{RotCenter.Y},{TotalRotAngle},{Angle},{subBoardId},{SequenceID},{SelectColors},{ImageBright},{ImageKey},{SearchShift.X},{MarkShift.X},{CPUPinStaShfit.X},,{SearchShift.Y},{MarkShift.Y},{CPUPinStaShfit.Y},{CPUPinStaAngleX},{CPUPinStaAngleY},{PinXShfit},{PinYShfit},{Item},{Target},{Value},{Result},{FovId},{Model},{Code},{Package},{MountingName},{ComponentBarcode},{ConfirmTimes},{ConfirmResult},{DiffXy.X},{DiffXy.Y},{Defectcode},{UserDefindConfirm},{CompelNG},{TargetResultType}"; 
        //}
    }
}
