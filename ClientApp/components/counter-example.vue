<template>
    <div>
        <h1>Counter</h1>

        <p>This is a simple example of a Vue.js component & SignalR. To see how this data is coming from the server, open this page in more than one browser tab.  You will notice how the count is synchronized between the two, because the data is being pushed to each client from the server.</p>

        <p>
            Auto count: <strong>{{ count }}</strong><br />
            Time elapsed: <strong>{{ timeElapsed }}</strong>
        </p>

    </div>
</template>

<script>
        
    export default {
        data() {
            return {
                connection: null,
                count: 0,
                timeElapsed: "0 seconds"
            }
        },
        created: function ()
        {
            this.connection = new this.$signalR.HubConnection('/count');

        },
        mounted: function () {
            this.connection.start();
            
            this.connection.on('increment', data => {
                this.count = data.Count;
                this.timeElapsed = data.TimeElapsed;
            });
        }
    }
</script>

<style>
</style>
