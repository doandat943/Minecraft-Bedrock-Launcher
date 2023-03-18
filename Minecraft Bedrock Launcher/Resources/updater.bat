@ECHO OFF
title UPDATER (@doandat943)
color 0a
ECHO UPDATE NOW
taskkill /IM %1.exe /F
del /F %2
curl.exe --output %2 --url https://cloud.kamvdta.xyz:2023/application/%3/%4.exe
start "" %2
del %0