On Error Resume Next
Dim pattList, regexObj, fso
pattList	=	Array("\.vshost\.exe$", "BuildLog.htm$", "_manifest$", "\\(bin|obj)\\.*(Debug|Release)\\.+\.exe$", "\.FileListAbsolute\.txt$", "upgradelog.xml$", "Thumbs\.db$", "ehthumbs\.db$","\\(bin|obj)\\.*(Debug|Release)\\.+\.resources$")
extList		=	Array("cache", "filters", "idb", "ilk", "ipch", "lastbuildstate", "log", "ncb", "obj", "pch", "pdb", "sdf", "suo", "tlog", "user", "manifest")

Set regexObj = New RegExp
regexObj.IgnoreCase = True
Set fso = WScript.CreateObject("Scripting.FileSystemObject")
Set dir = fso.GetFolder(fso.GetAbsolutePathName("."))

parentLen		=	Len (dir.Path)
nSizeDeleted 	=	0
nFileDeleted 	=	0
nDirDeleted 	=	0
nTotalSize		=	0
nTotalFile		=	0
nTotalDir		=	0
strLog			=	""


startStamp = Timer
DFS dir
endStamp = Timer
timeDiff = Int((endStamp-startStamp) * 1000)

dfsResult = "Tổng số tập tin" & vbTab & nTotalFile & vbLf & "Tổng dung lượng" & vbTab & FormatNumber(nTotalSize / 1024, 2) & " KB" & vbLf & "Tổng số thư mục" & vbTab & nTotalDir & vbLf & "Thời gian thực thi" & vbTab & timeDiff & " ms" & vbLf & "---------------------------------"

If nDirDeleted + nFileDeleted = 0 Then
	MsgBox dfsResult & vbLf & "Không tìm thấy gì!", 0, "Kết quả"
Else
	delResult = "Số tập tin đã xóa" & vbTab & nFileDeleted & vbLf & "Dung lượng đã xóa" & vbTab & FormatNumber(nSizeDeleted / 1024, 2) & " KB (" & FormatNumber(100 * nSizeDeleted / nTotalSize, 3) & "%)" & vbLf & "Thư mục trống" & vbTab & nDirDeleted
	button = MsgBox (dfsResult & vbLf & delResult & vbLf & "Xem nhật ký chi tiết?" , vbOKCancel + vbQuestion, "Kết quả")
	If button = vbOK Then
		CompleteLog
		Set objShell = WScript.CreateObject( "WScript.Shell" )
		tempPath = objShell.ExpandEnvironmentStrings("%Temp%")
		logFilePath = WriteDelDirLogToFile(tempPath)
		objShell.Run logFilePath
	End If
End If

Sub DFS(currDir)
	For Each folder in currDir.SubFolders
		DFS folder
	Next 	
	For Each file In currDir.Files
		ProcessFile file
	Next	
	ProcessDir currDir
End Sub

Sub ProcessDir(dir)
	If CheckDir(dir) Then
		DeleteDir dir
	End If	
End Sub

Sub ProcessFile(file)
	IncFileCounter file.Size
	If CheckFile (file) Then
		DeleteFile (file)
	End If
End Sub

Function CheckDir(dir)
	IncFolderCounter
	CheckDir = dir.Files.Count + dir.SubFolders.Count = 0
End Function

Function CheckFile(file)
	ext = fso.GetExtensionName(file)
	If InArray (ext, extList) Then
		CheckFile = True
		Exit Function 
	End If
	For Each patt In pattList
		regexObj.Pattern = patt
		If regexObj.Test(file.Path) Then
			CheckFile = True
			Exit Function 
		End If		
	Next
	CheckFile = False 
End Function

Sub DeleteDir(dir)
	WriteLog dir.Path, vbTab
	dir.Delete
	nDirDeleted = nDirDeleted + 1
End Sub

Sub DeleteFile(file)
	WriteLog file.Path, file.Size
	nSizeDeleted = nSizeDeleted + file.Size
	nFileDeleted = nFileDeleted + 1	 	
	file.Delete(True)	
End Sub

Sub IncFileCounter(fileSize)
	nTotalSize = nTotalSize + fileSize
	nTotalFile = nTotalFile + 1
End Sub

Sub IncFolderCounter
	nTotalDir = nTotalDir + 1
End Sub

Function InArray(item, arr)
	For Each i In arr
		If LCase(i) = LCase(item) Then
			InArray = True
			Exit Function
		End If		
	Next	
	InArray = False
End Function

Sub WriteLog(p, s)
	p = Mid(p, parentLen + 1)
	strLog = strLog & s & vbTab & p & vbCrLf
End Sub

Sub CompleteLog
	head = "Thư mục thực thi: " & dir.Path & vbCrLf & vbCrLf
	head = head & dfsResult & vbCrLf & delResult & vbCrLf & vbCrLf & "=================================" & vbCrLf
	strLog = head & strLog
End Sub

Function WriteDelDirLogToFile(path)
	logFilePath = path & "\\CleanLog-" & Int(startStamp) & ".txt"
	Set oLogFile = fso.CreateTextFile(logFilePath,True,True)
	oLogFile.Write strLog
	oLogFile.Close
	WriteDelDirLogToFile = logFilePath
End Function