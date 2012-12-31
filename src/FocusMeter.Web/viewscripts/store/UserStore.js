Ext.define('TP.store.UserStore', {
	extend : 'Ext.data.Store',
	model: 'TP.model.UserModel',
	data   : [
			{ name: 'Ed', email: 'edd@scalepoint.com' },
			{ name: 'Vladimir', email: 'vda@scalepoint.com' },
			{ name: 'Eugene', email: 'epr@scalepoint.com' },
			{ name: 'Michael', email: 'mic@scalepoint.com' },
			{ name: 'Tomas', email: 'tom@scalepoint.com' },
			{ name: 'Scott', email: 'sco@scalepoint.com' }
		]
});