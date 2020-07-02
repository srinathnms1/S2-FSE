const generator = require('@proerd/swagger-ts-template')
const fetch = require('node-fetch')
const prettier = require("prettier")

async function run() {
  const authApiDef = await fetch('http://localhost:7001/swagger/v1/swagger.json').then(r => r.json())
  await generator.genPaths(authApiDef, {
    output: "src/api-client/auth",
    typesOpts: { hideComments: true },
    moduleStyle: "esm"
  });
  console.log('Auth Api client generated successfully.')

  const bookingApiDef = await fetch('http://localhost:7002/swagger/v1/swagger.json').then(r => r.json())
  await generator.genPaths(bookingApiDef, {
    output: "src/api-client/booking",
    typesOpts: { hideComments: true },
    moduleStyle: "esm"
  })
  console.log('Booking Api client generated successfully.')

  const vehicleApiDef = await fetch('http://localhost:7003/swagger/v1/swagger.json').then(r => r.json())
  await generator.genPaths(vehicleApiDef, {
    output: "src/api-client/vehicle",
    typesOpts: { hideComments: true },
    moduleStyle: "esm"
  })
  console.log('Vehicle Api client generated successfully.')
}
run()