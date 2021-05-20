
#include <stdio.h>
#include <stdlib.h>
#include <string.h>

void congratulateUser(const char *userName)
{
        char buffer[80];
        /* BAD: this could overflow the buffer if the UserName is long */
        sprintf(buffer, "Congratulations, %s!", userName);
        
        printf("%s\n", buffer);
}

void branchingFactor()
{
   int factor = atoi(getenv("BRANCHING_FACTOR"));
   /* GOOD: Prevent overflow by checking the input */
   /*if (factor < 0 || factor > 1000) {
       log("Factor out of range (%d)\n", factor);
       return -1;
   }
   */
   // This line can allocate too little memory if factor
   // is very large.
   char **root_node = (char **) malloc(factor * sizeof(char *));
}

int main() {
   char aName[256] = {0};
        
   /* my first program in C */
   printf("What is your name?\n");
   
   scanf("%s", aName);
   
   congratulateUser(aName);
        
   branchingFactor();
   
   return 0;
}
