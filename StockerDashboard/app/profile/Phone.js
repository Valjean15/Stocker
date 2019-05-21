/**
 * Archivo de configuracion cuando la aplicacion
 * se inicia desde un telefono
 */
Ext.define('StockerDashboard.profile.Phone', {
    extend: 'Ext.app.Profile',

    /**
     * Dependencias cuando se inicia el perfil de telefono
     */
    requires: [
        //'StockerDashboard.view.phone.*'
    ],

    /**
     * Mappeo de las vistas para cuando se utiliza telefono
     */
    views: {
        //email: 'StockerDashboard.view.phone.email.Email',
        //inbox: 'StockerDashboard.view.phone.email.Inbox',
        //compose: 'StockerDashboard.view.phone.email.Compose',
        //searchusers: 'StockerDashboard.view.phone.search.Users'
    },

    /**
     * Indica que el perfil esta activo
     */
    isActive: function () {
        return Ext.platformTags.phone;
    },

    /**
     * Accion al momento de ejecutarse este perfil
     */
    launch: function () {
        // Se utiliza para un reemplazo mas rapido de los estilos
        // para cuando el perfil es telefono
        Ext.getBody().addCls('phone');
    }
});
