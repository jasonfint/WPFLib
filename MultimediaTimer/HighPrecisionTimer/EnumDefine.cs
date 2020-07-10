namespace HighPrecisionTimer
{
    public enum TimerError
    {
        /// <summary>没有错误</summary>
        MMSYSERR_NOERROR = 0,

        /// <summary>常规错误码</summary>
        MMSYSERR_ERROR = 1,
        /// <summary>ptc 为空，或 cbtc 无效，或其他错误</summary>
        TIMERR_NOCANDO = 97,
        /// <summary>无效参数</summary>
        MMSYSERR_INVALPARAM = 11,
    }

    public enum EventType01
    {
        /// <summary>单次执行</summary>
        TIME_ONESHOT = 0x0000,
        /// <summary>循环执行</summary>
        TIME_PERIODIC = 0x0001,
    }

    public enum EventType02
    {
        /// <summary>定时器到期时，调用回调方法。这是默认值</summary>
        TIME_CALLBACK_FUNCTION = 0x0000,
        /// <summary>定时器到期时，调用 setEvent</summary>
        TIME_CALLBACK_EVENT_SET = 0x0010,
        /// <summary>定时器到期时，调用 PulseEvent</summary>
        TIME_CALLBACK_EVENT_PULSE = 0x0020,
        /// <summary>防止在调用 timeKillEvent 函数之后发生事件</summary>
        TIME_KILL_SYNCHRONOUS = 0x0100,
    }
}
