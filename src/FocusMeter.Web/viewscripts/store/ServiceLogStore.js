Ext.define('TP.store.ServiceLogStore', {
	extend: 'Ext.data.Store',
	model: 'TP.model.ServiceLogModel',
	autoLoad: true,
	proxy: {
		type: 'ajax',
		url: 'viewscripts/testdata/serviceslogs.json',
		reader: {
			type: 'json',
			root: 'Items',
			totalProperty: 'TotalItems',
			successProperty: 'success'
		}
	}
});