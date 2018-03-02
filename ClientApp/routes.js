import CounterExample from 'components/counter-example'
import Weather from 'components/weather'
import HomePage from 'components/home-page'

export const routes = [
    { path: '/', component: HomePage, display: 'Home', style: 'glyphicon glyphicon-home' },
    { path: '/counter', component: CounterExample, display: 'Counter', style: 'glyphicon glyphicon-education' },
    { path: '/weather', component: Weather, display: 'Easton Weather', style: 'glyphicon glyphicon-cloud' }
]
