REM  logfile is %1

REM ======================================================================
REM Disable IE8 RunOnce tour
REM ======================================================================
echo Disabling IE8 RunOnce >> %1
reg import IE8RunOnceDone.reg >> %1
REM ======================================================================
REM Disable IE8 AutoRecovery
REM ======================================================================
echo Disabling IE8 AutoRecovery >> %1
reg import DisableIEAutoRecovery.reg >> %1

REM ======================================================================
REM Disable IE Enhanced Security Configuration
REM ======================================================================
echo disbaleIEESC.vbs >> %1
cscript.exe DisableIEESC.vbs