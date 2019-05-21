/**
 * Archivo de configuracion cuando la aplicacion
 * se inicia desde un tablet
 */
Ext.define('StockerDashboard.profile.Tablet', {
    extend: 'Ext.app.Profile',

    /**
     * Dependencias cuando se inicia el perfil de tablet
     */
    requires: [
        //'StockerDashboard.view.tablet.*'
    ],

    /**
     * Mappeo de las vistas para cuando se utiliza tablet
     */
    views: {
        //email: 'StockerDashboard.view.tablet.email.Email',
        //inbox: 'StockerDashboard.view.tablet.email.Inbox',
        //compose: 'StockerDashboard.view.tablet.email.Compose',
        //searchusers: 'StockerDashboard.view.tablet.search.Users'
    },

    /**
     * Indica que el perfil esta activo
     */
    isActive: function () {
        return !Ext.platformTags.phone;
    }
});
