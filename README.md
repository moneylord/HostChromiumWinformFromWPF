# HostChromiumWinformFromWPF

- CEF Sharp Lib의 WPF Project의 경우 OSR(Off-screen Rendering) 기능으로 인한 IME 입력이 되지 않는 Bug가 존재한다.
- 이로인해 부득이하게 WPF 환경에서 Chromium Browser를 사용하기위해 CEFSharp Winform Lib를 Host하여 WPF 에서 UserControl로 사용한다.

- Winform Project에서 UserControl에 Chromium Web Browser를 올리고 해당 User Control을 WPF의 WindowsFormsHost 객체의 Child로 사용하는 방법이다.
