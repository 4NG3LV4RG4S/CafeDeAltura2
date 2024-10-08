function getBrowserInfo() {
    return new Promise((resolve, reject) => {
        let navegador = 'Desconocido';
        let navegadorVersion = 'Desconocido';
        let sistemaOperativo = 'Desconocido';
        let dispositivo = 'Desconocido';
        let latitud = 'Desconocido';
        let longitud = 'Desconocido';

        // Usar navigator.userAgentData si est� disponible
        if (navigator.userAgentData) {
            navigator.userAgentData.getHighEntropyValues(['platform', 'uaFullVersion', 'brands'])
                .then((userAgentData) => {
                    const firstBrand = userAgentData.brands[0]; // Acceder a la primera marca
                    navegador = firstBrand.brand; // Marca (navegador) en la posici�n cero
                    navegadorVersion = firstBrand.version; // Versi�n del navegador

                    sistemaOperativo = userAgentData.platform;
                    dispositivo = userAgentData.mobile ? 'Mobile' : 'Desktop';

                    obtenerGeolocalizacion().then(geoInfo => {
                        const deviceInfo = {
                            navegador,
                            navegadorVersion,
                            sistemaOperativo,
                            dispositivo,
                            latitud: geoInfo.latitud,
                            longitud: geoInfo.longitud
                        };

                        // Aqu� almacenas los datos en tu registro de sesi�n
                        localStorage.setItem('browserInfo', JSON.stringify(deviceInfo)); // ejemplo usando localStorage

                        resolve(deviceInfo); // Retornar el objeto de informaci�n del dispositivo
                    });
                }).catch(err => reject(err));
        } else {
            // Si userAgentData no est� disponible, usar navigator.userAgent
            navegador = navigator.userAgent;
            sistemaOperativo = navigator.platform;
            dispositivo = /Mobi|Android/i.test(navigator.userAgent) ? 'Mobile' : 'Desktop';

            obtenerGeolocalizacion().then(geoInfo => {
                const deviceInfo = {
                    navegador,
                    navegadorVersion: 'Desconocido',
                    sistemaOperativo,
                    dispositivo,
                    latitud: geoInfo.latitud,
                    longitud: geoInfo.longitud
                };

                console.log(deviceInfo);

                // Aqu� almacenas los datos en tu registro de sesi�n
                localStorage.setItem('browserInfo', JSON.stringify(deviceInfo));

                resolve(deviceInfo);
            }).catch(err => reject(err));
        }
    });
}

// Funci�n para obtener geolocalizaci�n
function obtenerGeolocalizacion() {
    return new Promise((resolve, reject) => {
        if (navigator.geolocation) {
            navigator.geolocation.getCurrentPosition((position) => {
                const geoInfo = {
                    latitud: position.coords.latitude,
                    longitud: position.coords.longitude
                };
                resolve(geoInfo);
            }, (error) => {
                console.error('Error al obtener la geolocalizaci�n:', error);
                resolve({ latitud: 'Desconocido', longitud: 'Desconocido' }); // Manejar error con valores desconocidos
            });
        } else {
            console.error('La geolocalizaci�n no est� disponible.');
            resolve({ latitud: 'Desconocido', longitud: 'Desconocido' }); // Si no est� disponible
        }
    });
}

// Exponer la funci�n a Blazor
window.browserInfo = {
    getDeviceInfo: getBrowserInfo
};
