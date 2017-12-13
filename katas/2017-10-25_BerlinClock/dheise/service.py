#!/usr/bin/env python
import web
import re
import json

urls = (
    '/clock/(.*)', 'get_clock'
)

app = web.application(urls, globals())

class get_clock:
    def GET(self, clockString):
        web.header('Content-Type', 'application/json')
        web.header('Access-Control-Allow-Origin', '*')
        web.header('Access-Control-Allow-Credentials', 'true')

        return self.get_output(clockString)
 
    def get_output(self, clockString):
        hours, minutes, seconds = self.parse_time(clockString)
        
        output = {
            'filledRowSegments': [ hours / 5, hours % 5, minutes / 5, minutes % 5 ],
            'secondIndicator': True if seconds % 2 == 1 else False
        }

        return json.dumps(output)

    def parse_time(self, clockString):
        match = re.match('(\d{2})(\d{2})(\d{2})', clockString)

        hours = int(match.group(1))
        minutes = int(match.group(2))
        seconds = int(match.group(3))

        return hours, minutes, seconds

if __name__ == "__main__":
    app.run()