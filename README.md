# SkelFinder
Tool for finding skeletons in binary files.<br/>
<img src="help/skelFinderScreen.png" width="256" height="172" />

##ToolStripMenu:<br/>
###File:<br/>
<sup>[Open...] - open any file for finding skel.</sup>
<sup>[Eport] - export cur skel to [.SkelFinder], collada [.dae], valve [.smd].</sup>
<sup>[Exit] - close Form.</sup>
###Tools:<br/>
<sup>[TextBox Mode] - activate TextBox mode.(full template editing)</sup>
<sup>[ListBox Mode] - activate ListBox mode.(adding and editing cmd using the UI)</sup>
<sup>[list <-> text] - copy all cmd from not active mode in active mode.(the inactive template will be cleared)</sup>
<sup>[open temp.txt] - loads cmd(and params) from temp file.</sup>
<sup>[save temp.txt] - save cmd(and params) in temp file from active mode.</sup>
<sup>[save BMP] - save 3D preview to bmp picture.</sup>
###CmdTabPages:<br/>
####name - will read the string and assigned as the name of the bone.<br/>
<sup>[NumericUpDown] - string length if fixed. (or '-1' to read all characters up to the first null byte)</sup>
<sup>[DropDown] - to select the mode. (fixed or read the length value before the string)</sup>
<sup>[CheckBox][\x00] - indicate if there is a null byte at the end of the string.</sup>
####rotation - will read a rotation with the specified type and auto converted to a 4x4 matrix for the bone.<br/>
<sup>[DropDown] - rotation type (Mat43, Mat44, Quat, Euler[rad,deg])</sup>
<sup>[DropDown] - value type for cur rotation.</sup>
<sup>if selected rotation UlerAngles: [i]DropDown[/i] - transpose value (xyz, yxz, e.t.c)</sup>
<sup>[CheckBox][transpose] - Transposes the rows and columns of a matrix.(or quat)</sup>
<sup>[CheckBox][inverse/normalize] - Inverts the specified matrix. (or normalize for quat)</sup>
####position - will read a vector3 with the specified type, and set the position in the bone matrix.<br/>
<sup>[DropDown] - value type.</sup>
####parent - will read parent, and set in the bone.<br/>
<sup>[DropDown] - to select the mode. (string or integer)</sup>
<sup>if a string, then the rest of the parameters are the same as for the command "name"</sup>
####seek - skip specified number of bytes.<br/>
<sup>[DropDown] - to select the mode. (fixed or read the value from file)</sup>
<sup>[CheckBox][mul] - multiply the read value by the specified value.</sup>
<sup>[NumericUpDown] - the value by which the read value will be multiplied.</sup>
####offset - the new position in the current stream(begin).divides the template into cycles.<br/>
FOR ALL CMD: <br/>
<sup>[Button][Add] - add current command to template.</sup>
<sup>[Button][R] - overwrite the selected command in the template with the current command. (for editing, only for ListBox mode)</sup>
###Template:<br/>
<sup>[CheckBox][bigE] - whether to use big Endian when reading.</sup>
<sup>[CheckBox][mltply] - multiply child bones by parent. (from local to world space)</sup>
<sup>[NumericUpDown] - specify how many bones to read from the file.</sup>
<sup>[Button][F] - open file. (red if no file is open, and green when open)</sup>
<sup>[ListBox]/[TextBox] - template entry field.</sup>
<sup>[Button][↑] - move selected cmd up.(only for ListBox mode)</sup>
<sup>[Button][↓] - move selected cmd down.(only for ListBox mode)</sup>
<sup>[Button][clr] - clear all cmd from active(Template) mode.</sup>
<sup>[Button][del] - remove selected cmd.(only for ListBox mode)</sup>
<sup>[Button][run] - read bones from a file using the active template and the specified parameters.</sup>
###Debug:<br/>
<sup>[NumericUpDown] - number of decimal places when printing.</sup>
<sup>[TextBox] - bebug entry field.</sup>
<sup>[Button][clr]/[matrix]/[name]/[pos]/[prnt] - printing information.</sup>
###3D View:<br/>
<sup>[PictureBox] - draw 3d skeleton.</sup>
<sup>[CheckBox][render name] - render name in 3d view.</sup>
<sup>[Button][color] - change cbackground color.</sup>
<sup>[Button][reset] - reset 3d view.(or click middle mouse button)</sup>
<sup>[Mouse] - LKM DOWN AND MOVE for rotation. whell for zoom.</sup>
[i]warning: "if the position goes beyond the boundaries of the file during reading, it will return those bones that were read before the error, also the multiplication will not be performed(if use), and the parent will not be converted to an integer from string(if use)[/i]
