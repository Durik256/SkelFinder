# SkelFinder
Tool for finding skeletons in binary files.<br/>
<img src="help/skelFinderScreen.png" width="256" height="172" />

[b]ToolStripMenu[/b][1]:<br/>
File:<br/>
--[u]Open...[/u] - open any file for finding skel.<br/>
--[u]Eport[/u] - export cur skel to [.SkelFinder], collada [.dae], valve [.smd].<br/>
--[u]Exit[/u] - close Form.<br/>
-Tools:<br/>
--[u]TextBox Mode[/u] - activate TextBox mode.(full template editing)<br/>
--[u]ListBox Mode[/u] - activate ListBox mode.(adding and editing cmd using the UI)<br/>
--[u]ist <-> text[/u] - copy all cmd from not active mode in active mode.(the inactive template will be cleared)<br/>
--[u]open temp.txt[/u] - loads cmd(and params) from temp file.<br/>
--[u]save temp.txt[/u] - save cmd(and params) in temp file from active mode.<br/>
--[u]save BMP[/u] - save 3D preview to bmp picture.<br/>
[b]CmdTabPages[/b][2]:<br/>
--[u]name[/u] - will read the string and assigned as the name of the bone.<br/>
>>>[i]NumericUpDown[/i] - string length if fixed. (or '-1' to read all characters up to the first null byte)<br/>
>>>[i]DropDown[/i] - to select the mode. (fixed or read the length value before the string)<br/>
>>>[i]CheckBox[/i][\x00] - indicate if there is a null byte at the end of the string.<br/>
--[u]rotation[/u] - will read a rotation with the specified type and auto converted to a 4x4 matrix for the bone.<br/>
>>>[i]DropDown[/i] - rotation type (Mat43, Mat44, Quat, Euler[rad,deg])<br/>
>>>[i]DropDown[/i] - value type for cur rotation.<br/>
>>>if selected rotation UlerAngles: [i]DropDown[/i] - transpose value (xyz, yxz, e.t.c)<br/>
>>>[i]CheckBox[/i][transpose] - Transposes the rows and columns of a matrix.(or quat)<br/>
>>>[i]CheckBox[/i][inverse/normalize] - Inverts the specified matrix. (or normalize for quat)<br/>
--[u]position[/u] - will read a vector3 with the specified type, and set the position in the bone matrix.<br/>
>>>[i]DropDown[/i] - value type.<br/>
--[u]parent[/u] - will read parent, and set in the bone.<br/>
>>>[i]DropDown[/i] - to select the mode. (string or integer)<br/>
>>>if a string, then the rest of the parameters are the same as for the command "name"<br/>
--[u]seek[/u] - skip specified number of bytes.<br/>
>>>[i]DropDown[/i] - to select the mode. (fixed or read the value from file)<br/>
>>>[i]CheckBox[/i][mul] - multiply the read value by the specified value.<br/>
>>>[i]NumericUpDown[/i] - the value by which the read value will be multiplied.<br/>
--[u]offset[/u] - the new position in the current stream(begin).divides the template into cycles.<br/>
FOR ALL CMD: <br/>
>>[i]Button[/i][Add] - add current command to template.<br/>
>>[i]Button[/i][R] - overwrite the selected command in the template with the current command. (for editing, only for ListBox mode)<br/>
[b]Template[/b][3]:<br/>
>>>[i]CheckBox[/i][bigE] - whether to use big Endian when reading.<br/>
>>>[i]CheckBox[/i][mltply] - multiply child bones by parent. (from local to world space)<br/>
>>>[i]NumericUpDown[/i] - specify how many bones to read from the file.<br/>
>>>[i]Button[/i][F] - open file. (red if no file is open, and green when open)<br/>
>>>[i]ListBox[/i]/[i]TextBox[/i] - template entry field.<br/>
>>>[i]Button[/i][↑] - move selected cmd up.(only for ListBox mode)<br/>
>>>[i]Button[/i][↓] - move selected cmd down.(only for ListBox mode)<br/>
>>>[i]Button[/i][clr] - clear all cmd from active(Template) mode.<br/>
>>>[i]Button[/i][del] - remove selected cmd.(only for ListBox mode)<br/>
>>>[i]Button[/i][run] - read bones from a file using the active template and the specified parameters.<br/>
[b]Debug[/b][4/5]:<br/>
>>>[i]NumericUpDown[/i] - number of decimal places when printing.<br/>
>>>[i]TextBox[/i] - bebug entry field.<br/>
>>>[i]Button[/i][clr]/[matrix]/[name]/[pos]/[prnt] - printing information.<br/>
[b]3D View[/b][6]:<br/>
>>>[i]PictureBox[/i] - draw 3d skeleton.<br/>
>>>[i]CheckBox[/i][render name] - render name in 3d view.<br/>
>>>[i]Button[/i][color] - change cbackground color.<br/>
>>>[i]Button[/i][reset] - reset 3d view.(or click middle mouse button)<br/>
>>>[i]Mouse[/i] - LKM DOWN AND MOVE for rotation. whell for zoom.<br/>
[i]warning: "if the position goes beyond the boundaries of the file during reading, it will return those bones that were read before the error, also the multiplication will not be performed(if use), and the parent will not be converted to an integer from string(if use)[/i]
