Ext.define('TP.view.servicelogs.Details', {
	extend: 'Ext.window.Window',
	alias: 'widget.detail',
	title: 'Show log item',
	layout: 'fit',
	width: 700,
	border: false,
	modal: true,
	resizable: true,
	draggable: true,
	autoShow: true,

	initComponent: function () {
		this.items = [
				{
					xtype: 'form',
					frame: true,
					fieldDefaults: {
						anchor: '100%'
					},
					items: [
						{
							xtype: 'textfield',
							name: 'Action',
							fieldLabel: 'Action',
							readOnly: true
						},
						{
							xtype: 'textarea',
							name: 'Request',
							fieldLabel: 'Request',
							height: 250,
							readOnly: true
						},
						{
							xtype: 'textarea',
							name: 'Response',
							fieldLabel: 'Response',
							height: 250,
							readOnly: true
						},
						{
							xtype: 'datefield',
							name: 'CreatedDate',
							fieldLabel: 'Created Date',
							format: 'd-m-Y H:i:s',
							altFormats: 'MS',
							width: 100,
							readOnly: true
						}
					]
				}
			];
		this.buttons = [{
			text: 'Close',
			scope: this,
			handler: this.close
		}];
		this.callParent(arguments);
	}
});
