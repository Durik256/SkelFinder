# SkelFinder
Tool for finding skeletons in binary files.<br/>
<img src="help/skelFinderScreen.png" width="256" height="172" />

## ToolStripMenu:<br/><br/>
### File:<br/><br/>
<sup>-[Open...] - open any file for finding skel.</sup><br/>
<sup>-[Eport] - export cur skel to [.SkelFinder], collada [.dae], valve [.smd].</sup><br/>
<sup>-[Exit] - close Form.</sup><br/>
### Tools:<br/><br/>
<sup>-[TextBox Mode] - activate TextBox mode.(full template editing)</sup><br/>
<sup>-[ListBox Mode] - activate ListBox mode.(adding and editing cmd using the UI)</sup><br/>
<sup>-[list <-> text] - copy all cmd from not active mode in active mode.(the inactive template will be cleared)</sup><br/>
<sup>-[open temp.txt] - loads cmd(and params) from temp file.</sup><br/>
<sup>-[save temp.txt] - save cmd(and params) in temp file from active mode.</sup><br/>
<sup>-[save BMP] - save 3D preview to bmp picture.</sup><br/>
### CmdTabPages:<br/><br/>
#### name - will read the string and assigned as the name of the bone.<br/><br/>
<sup>-[NumericUpDown] - string length if fixed. (or '-1' to read all characters up to the first null byte)</sup><br/>
<sup>-[DropDown] - to select the mode. (fixed or read the length value before the string)</sup><br/>
<sup>-[CheckBox][\x00] - indicate if there is a null byte at the end of the string.</sup><br/>
#### rotation - will read a rotation with the specified type and auto converted to a 4x4 matrix for the bone.<br/><br/>
<sup>-[DropDown] - rotation type (Mat43, Mat44, Quat, Euler[rad,deg])</sup><br/>
<sup>-[DropDown] - value type for cur rotation.</sup><br/>
<sup>-if selected rotation UlerAngles: [i]DropDown[/i] - transpose value (xyz, yxz, e.t.c)</sup><br/>
<sup>-[CheckBox][transpose] - Transposes the rows and columns of a matrix.(or quat)</sup><br/>
<sup>-[CheckBox][inverse/normalize] - Inverts the specified matrix. (or normalize for quat)</sup><br/>
#### position - will read a vector3 with the specified type, and set the position in the bone matrix.<br/><br/>
<sup>-[DropDown] - value type.</sup><br/>
#### parent - will read parent, and set in the bone.<br/><br/>
<sup>-[DropDown] - to select the mode. (string or integer)</sup><br/>
<sup>-if a string, then the rest of the parameters are the same as for the command "name"</sup><br/>
#### seek - skip specified number of bytes.<br/><br/>
<sup>-[DropDown] - to select the mode. (fixed or read the value from file)</sup><br/>
<sup>-[CheckBox][mul] - multiply the read value by the specified value.</sup><br/>
<sup>-[NumericUpDown] - the value by which the read value will be multiplied.</sup><br/>
<sup>-[CheckBox][n] - takes data from the "name" tab, skips n lines (bytes) in a loop.</sup><br/>
#### offset - the new position in the current stream(begin).divides the template into cycles.<br/><br/>
FOR ALL CMD: <br/><br/>
<sup>-[Button][Add] - add current command to template.</sup><br/>
<sup>-[Button][R] - overwrite the selected command in the template with the current command. (for editing, only for ListBox mode)</sup><br/>
### Template:<br/><br/>
<sup>-[CheckBox][bigE] - whether to use big Endian when reading.</sup><br/>
<sup>-[CheckBox][mltply] - multiply child bones by parent. (from local to world space)</sup><br/>
<sup>-[NumericUpDown] - specify how many bones to read from the file.</sup><br/>
<sup>-[Button][F] - open file. (red if no file is open, and green when open)</sup><br/>
<sup>-[ListBox]/[TextBox] - template entry field.</sup><br/>
<sup>-[Button][↑] - move selected cmd up.(only for ListBox mode)</sup><br/>
<sup>-[Button][↓] - move selected cmd down.(only for ListBox mode)</sup><br/>
<sup>-[Button][clr] - clear all cmd from active(Template) mode.</sup><br/>
<sup>-[Button][del] - remove selected cmd.(only for ListBox mode)</sup><br/>
<sup>-[Button][run] - read bones from a file using the active template and the specified parameters.</sup><br/>
### Debug:<br/><br/>
<sup>-[NumericUpDown] - number of decimal places when printing.</sup><br/>
<sup>-[TextBox] - bebug entry field.</sup><br/>
<sup>-[Button][clr]/[matrix]/[name]/[pos]/[prnt] - printing information.</sup><br/>
### 3D View:<br/><br/>
<sup>-[PictureBox] - draw 3d skeleton.</sup><br/>
<sup>-[CheckBox][render name] - render name in 3d view.</sup><br/>
<sup>-[Button][color] - change background color.</sup><br/>
<sup>-[Button][reset] - reset 3d view.(or click middle mouse button)</sup><br/>
<sup>-[Mouse] - LBM DOWN AND MOVE for rotation. whell for zoom.</sup><br/>
### warning: "if the position goes beyond the boundaries of the file during reading, it will return those bones that were read before the error, also the multiplication will not be performed(if use), and the parent will not be converted to an integer from string(if use)<br/>
