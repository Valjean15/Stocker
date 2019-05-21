/**
 * Contiene todo los modelos que pertenecen a la vista 
 */
Ext.define('StockerDashboard.view.dashboard.DashboardModel', {
    extend: 'Ext.app.ViewModel',
    alias: 'viewmodel.dashboard',

    /**
     * Dependencias del modelo de la vista
     */
    requires: [
        'Ext.data.Store',
        'Ext.data.field.Integer',
        'Ext.data.field.String',
        'Ext.data.field.Boolean'
    ],

    /**
     * Stores locales de la vista
     */
    stores: {
    }
});
