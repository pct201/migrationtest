

select '<th class="cols">' + char(13) + char(9) + '<span style="display: inline-block;width:100px;">' + col  + '</span>' + char(13)+'</th>'
from tab where tab = 'Building_Additional_Insureds_Payees_Audit' order by Position


select 
'<asp:TemplateField HeaderText="' + col + '" >' + char(13) + char(9) +
	'<ItemStyle CssClass="cols" />' + char(13) + char(9) + 
	'<ItemTemplate>' + char(13) + char(9) + char(9) + 
		'<asp:Label ID="lbl' + col + '" runat="server" Text=''<%#' + 
			case datatype 
				when  'DateTime' then 'Eval("' + col + '") != DBNull.Value ? clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("' + col + '"))) : ""'
				when  'decimal' then 'clsGeneral.GetStringValue(Eval("' + col + '"))'
				when  'bit' then 'clsGeneral.FormatYesNoToDisplayForView(Eval("' + col + '"))'
				when  'int' then 'clsGeneral.GetStringValue(Eval("' + col + '")).Replace(".00", "")'
				when  'float' then 'clsGeneral.GetStringValue(Eval("' + col + '"))'
				else 'Eval("' + col + '")' end
			+ '%>'' Width="100px" ' + case when datatype='text' then 'CssClass="TextClip"' else '' end + '></asp:Label>'+ char(13) + char(9) + 
    '</ItemTemplate>' + char(13) + 
'</asp:TemplateField>'
from tab where tab = 'Building_Additional_Insureds_Payees_Audit' order by Position
