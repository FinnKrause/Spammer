   M S B A M L   `   `   `  ���� B  >Spammer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:Spamer2Spamer2      Spamer2.MainWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     'localclr-namespace:Spamer2     -     �Name$  Form1�� � Title$ Spammer LOL��$��655.442��$��687.231�����	#00000000 � 
ResizeMode$ NoResize=�����  �� EndPoint$ 0.5,1&� �� 
StartPoint$ 0.5,0&�.���  � Color$ Black�� � Offset$ 0Q�� $ 	#FF0023FF��$ 1Q�� $ 	#FF515464�� J� OpacityMask �� $ 0.5,1&�$ 0.5,0&�.��� $ Black��$ 0Q�� $ Black��$ 1Q�.��� -   $��
0,0,-19,-4q�$	��619��$	��Top=� � RowDefinitions �� 	 � ColumnDefinitions	 �� .+��� $
��Left=�$	��671��$	��616��$	��Top=�.@��� $
��Main�����	#FF00B9FF
���   �
���   �
 �   �.��� 
���   � �� 	 �� .+��� -   
 ��Name$
 BildBoxMainPage��$
��Left=�$	��658��$��0,-51,-19,-19q�$	��Top=�$	��684��$
��Fill=��� $��Eingabe��$��12,10,0,404q�
�������$
��Left=�$	��378��.���� -    ��Name$ 
txtEingabe�� �� TextWrapping$
 Wrap=�$��10,0,0,7q����	#00000000
�������
�������$	��136��$��Bottom=�$
��Left=�$	��343���� -    ��Name$ btnStop��$��STOP!��$��418,107,0,0q�$	��Top=�$��52��
����������	#FDFFFFFF���	#00DDDDDD$
��Left=�$	��222���� $��Aktionen��$	��174��$��
404,10,0,0q�$	��Top=�
�������
�������$
��Left=�$	��248���� -   $ btnLos��$
��Los!��$��
0,0,25,486q�
����������	#00615D5D
�������$��55��$��Bottom=�$��Right=�$	��222���� $��Durchläufe��$��74��$��
12,186,0,0q�$	��Top=�
�������$
��Left=�$	��640���� $&�� Geschwindigkeit in Millisekunden��$��78��$��
12,266,0,0q�$	��Top=�
�������$
��Left=�$	��640���� $��Fortschritt��$
��Left=�$��80��$��
12,346,0,0q�$	��Top=�$	��362��
�������.��� -    �Name$ pBFortschritt��$��Right=�$��35��$��0,10,7,0q�$	��Top=�$	��334�����	#00000000���	#00000000
���  ���� $	��Log��$��80��$��390,346,0,0q�$	��Top=�
�������$
��Left=�$	��262���� -   $ 	btnLeeren��$��
Log leeren��$
��Left=�$��399,372,0,0q�$	��Top=�$	��120��$��10(�$��39�����	#00DDDDDD
�������
��������� -	   $ 
btnÖffnen��$��Log öffnen��$��523,372,0,0q�$	��Top=�$��10(�$��39�����	#00DDDDDD
�������
�������$
��Left=�$	��120���� $	��Log��$
��Left=�$	��140��$��
12,424,0,0q�$	��Top=�$	��320��
�������.���� -
   $ txtLogImProgramm��$��Right=�$	��103��$��0,6,3,0q�$
 Wrap=�$	��Top=�$	��301��
�������
������ 
��������� $��Fehlermeldungen��$	��140��$��344,424,0,0q�$	��Top=�
�������$
��Left=�$	��308���� -   $ txtFehlerimProgram��$
��Left=�$	��100��$��352,450,0,0q�$
 Wrap=�$	��Top=�$	��290��
����������	#00000000
�������� -   $ pBDurchläufe��$
��Left=�$��14��$��
22,236,0,0q�$	��Top=�$	��546�� � Maximum$	 400Q� � Minimum$ 0Q����	#00000000���	#FF0C00FF� -   $ pBGEschwindigkeit�� � Value$ 0Q�$
��Left=�$��10��$��
22,322,0,0q�$	��Top=�$	��548��$ 10000Q�$	 750Q����	#00E6E6E6
����������	#FF0C00FF�� -    ��Name$ lblGeschwindigkeitMinimum��$��10��$��18,280,-1936,0q�$	��Top=�$��26��
��������� -   $ lblGeschwindigkeitMaximum��$��10.000��$��528,282,-2478,0q�$	��Top=� J� RenderTransformOrigin$ 1.177,0.442&�$��26��
��������� $��1��$��
18,196,0,0q�$	��Top=�$ 1.177,0.442&�$��26��
�������$
��Left=�$��22���� -   $ lblDurchläufeMaximum��$	��400��$��524,198,0,0q�$	��Top=�$ 1.177,0.442&�$��26��
�������$
��Left=�$��66���� -   $ txtAnzeigeDurchläufe��$��40��$��580,210,0,0q�$
 Wrap=�$	��Top=����	#00000000
�������
�������$
��Left=�$��60���� -   $ txtAnzeigeGeschwindigkeit��$��40��$��580,292,0,0q�$
 Wrap=�$	��Top=�
�������
����������	#02000000$
��Left=�$��60���� -    ��Name$ sldGeschwindigkeit��$
��Left=�$��20��$	��Top=�$	��552��$��
22,302,0,0q�$ 10000Q�$	 750Q� �� IsSnapToTickEnabled .  �� TickFrequency$	 250Q�
���  �����	#00000000���	#00000000�� -   $ sldDurchläufe��$��20��$	��Top=�$	 400Q�$ 1Q� � SmallChange$ 1Q�$��
22,216,0,0q� . 
���  ��
���  �����	#00000000$
��Left=�$	��550���� $��Einstellungen�����	#FF00C5FF.��� 
���   �$��
0,-17,0,-3q� �� .+��� -   $
 Bildbox��$
��Left=�$	��658��$��0,-51,-19,-19q�$	��Top=�$	��684��$
��Fill=��� -    ��Name$ cbEnter��$��ENTER nach Ausgabe��$��
359,68,0,0q�$	��Top=�$��16��
�������$
��Left=�$	��138���� -   $ 
cbAdvanced��$��Advanced Mode��$��359,147,0,0q�$	��Top=�
�������
�������$
��Left=�$	��116���� -   $ cbRandom��$��Random��$
��Left=�$��359,242,0,0q�
�������$	��Top=�$��68��	� -    	�Name$ 
CopyMethod��$��Copy, Paste
��$
��Left=�$��	23,53,0,0q�$	��Top=�$	��100��
�������	� -   $ WriteMethod�� d� 	IsChecked$
 TrueY�$��Type
��$
��Left=�$��
23,145,0,0q�$	��Top=�$��48��
�������$��17���� $��Spam-Methoden��$
��Left=�$	��215��$��8,27,0,0q�$	��Top=�$	��332��
��������� $����Die Copy-Paste Methode schreibt 
den gewünschten Text in die Zwischen-
ablage und kopiert ihn dann durch 
STRG + V. Besonders effektiv wenn es
 um Geschwindigkeit geht��$
��Left=�$��
111,47,0,0q�$	��Top=�$��92��$	��217��
������� � Cursor$
 Hand���� $����Schreibt den Text Buchstabe für Buch-
stabe.  Besonders gut, wenn man seine
Zwischenablage nicht löschen will
oder die erweiterten Syntax nutzen
möchte��$
��Left=�$��111,139,0,0q�$	��Top=�$��88��$	��217��
�������$
 Hand���� $��Weitere Einstellungen��$
��Left=�$	��308��$��
345,27,0,0q�$	��Top=�$	��311��
��������� $p��jFügt an die Ausgabe Ein "Enter" an, 
um die Nachricht in verscheide Zeilen 
aufzuteilen oder abzuschicken��$
��Left=�$��
441,82,0,0q�$	��Top=�
�������$	��211��
��������� $y��sGibt dem Nutzer mehr Möglichkeiten
Einstellungen zu vollziehen; Doch 
VORSICHT, damit könnt ihr euren PC
crashen!��$
��Left=�$��441,162,0,0q�$	��Top=�
�������$	��211���� $Y��SNur voll im "Type" Modus verfügbar;
Gibt bei jedem Durchlauf eine andere
Zahl aus;��$
��Left=�$��441,259,0,0q�$	��Top=�
�������$	��211���� $��Erweitere Syntax��$
��Left=�$��95��$��	8,240,0,0q�$	��Top=�$	��332��
��������� $����Schreibe in deine Eingabe "{}" um an diesem Punk die 
aktuelle Anzahl an Durchläufen einzubauen! Bsp:
Eingabe: Dies ist der {} Durchlauf!
Ausgabe: Dies ist der 1 Durchlauf!��$
��Left=�$��
23,256,0,0q�$	��Top=�$��71��$	��305��
�������$
 Hand���� $��Zurücksetzen��$
��Left=�$	��100��$��
10,335,0,0q�$	��Top=�$	��140��
��������� -   $ btnResetAll��$��Zurücksetzen��$
��Left=�$��
29,369,0,0q�$	��Top=�$��96��$��43�����	#00DDDDDD
�������
��������� $��Change Background Picture��$
��Left=�$	��100��$��155,335,0,0q�$	��Top=�$	��500��
�������.���� -   $ btnChangeBackground��$��Neues Bild 
auswählen��$
��Left=�$��	13,15,0,0q�$	��Top=�$��71��$��48���� -    ��Name$ lblAktuellerPfadAnzeíge��$
��Left=�$��266,364,0,0q�$
��Wrap=�$��Aktueller Pfad:��$	��Top=�
�������$��55��$	��359��4  .System.Windows.Automation.AutomationProperties   Name$ lblAktuellerPfadAnzeíge��