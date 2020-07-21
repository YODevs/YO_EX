#include <stdio.h>
#include <stdlib.h>
#include <stdbool.h>
#include <string.h>
#include "cli/cli.h"
#include "err/ncerror.h"

bool check_requirement();

int main(int argcindex, char *argval[]) {
    if(check_requirement() == false)
    {

        return 1;
    }
    if(argcindex == 1)
    {
        init_main_cli();
    }
    return 0;
}

bool check_requirement()
{
    char * sysdir = getenv("windir");
    if(sysdir == NULL)
    {
        set_error("Enviroment Variable Error","System ID / variable \"windir\" not found.\n"
                                              "You can create a system variable called \"windir\" with a value of \"C:\\Windows\"[Example !]",waitfusr);
        return  false;
    }  
    char * dotnetdir32[45];
    char * dotnetdir64[45];
    
    sprintf(dotnetdir32,"%s\\\Microsoft.NET\\Framework\\v3.5",sysdir);
    sprintf(dotnetdir64,"%s\\\Microsoft.NET\\Framework64\\v3.5",sysdir);
    
    return true;
}