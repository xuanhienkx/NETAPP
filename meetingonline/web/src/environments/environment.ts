// This file can be replaced during build by using the `fileReplacements` array.
// `ng build --prod` replaces `environment.ts` with `environment.prod.ts`.
// The list of file replacements can be found in `angular.json`.

export const environment = {
  languages: ['vi'],
  defaultLanguage: 'vi',
  environmentName: '',
  production: true,
  mediaEndpoint: 'http://localhost:8080/media',
  endpoint: 'http://localhost:8800/api',
  documentViewType: 'url',
  socialLoginProvider: {
    google: {
      clientId: '1039737655298-5iia6ab4r413g13pa7n93hhir2v1l3d9.apps.googleusercontent.com',
      secretKey: '4ln2fxruiop-xxQfoNu4TS6F'
    },
    facebook: {
      clientId: '2874573119441266',
      secretKey: '3f9df97b210a8ec13e3bc5bb55af9128'
    },
    linkedIn: {
      clientId: '1039737655298-5iia6ab4r413g13pa7n93hhir2v1l3d9.apps.googleusercontent.com',
      secretKey: '4ln2fxruiop-xxQfoNu4TS6F'
    }
  }
};

/*
 * For easier debugging in development mode, you can import the following file
 * to ignore zone related error stack frames such as `zone.run`, `zoneDelegate.invokeTask`.
 *
 * This import should be commented out in production mode because it will have a negative impact
 * on performance if an error is thrown.
 */
// import 'zone.js/dist/zone-error';  // Included with Angular CLI.
