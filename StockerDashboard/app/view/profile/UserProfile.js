/**
 * Pagina del perfil del usuario
 */
Ext.define('StockerDashboard.view.profile.UserProfile', {
    extend: 'Ext.Container',
    xtype: 'profile',
    cls: 'userProfile-container dashboard',

    /**
     * Modelo de datos de la vista
     */
    viewModel: { type: 'userprofile' },
    scrollable: 'y',
    
    items: [
    ]
});
