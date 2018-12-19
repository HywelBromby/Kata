## OCR Kata

### Approach
This is **not** intended as an optimal solution, either from verbosity, coding standard or performance. Rather it is a place to demonstrate a *breadth* of differnt techniques.

The basic approach was to create a spike for each story (a just get it working approach) then add a top level test around the funtionality then perform a refactor adding in strucutre.

#### Note I initially tried to shoe horn in working examples of each User story - this did NOT work, instead there are now commits for each story.There are still two aproaches remaining - a quick'n'dirty proof of concept and the "Full Fat" Version.

**I Will Update the solution to User Story 4 shortly**

## Terms / Things of Note
1. Where possible the full fat solution is built to SOLID prinicples (there are deviations from this)
2. I have tried to keep dependancies all running in one dierction by adding an aplication, feature and foundation folder, this is a variation of sitecores "Helix" apprach (https://helix.sitecore.net/principles/architecture-principles/index.html) e.g. Model projects have no dependancies (outside of netcore) Interface projects only depend on models
3. I have opted to use compostion over inthertence 
4. I try and seperate injection of dependancies from algorithmic complexity, this helps to make tests less fragile and also makes the code (IMO) easier to manage and adapt e.g. Services DO NO "WORK" - they simply chain together other things, Service tests use mocks but there should be few of them since all they do is chain things..

## Specification
https://code.joejag.com/coding-dojo/bank-ocr/

### Assumptions
1. For The Purposes of this Kata it is assumed that only valid filenames will be provided and that the files are in the correct format And that no Exception handeling is needed or Validation of each line
2. Outside of the result, logging is not required
3. No custom exception handleing is required
4. No NFRs have been provided.
5. Synchronus opertaion is fine - i.e. no Async is needed.

## Notes and learnings
*I should have spent more time on naming*
*I should have done all of the User stories as spike first and then gone back and refactored...*

### Formats
I should have modeled the "numbers" in a nicer way, e.g. constants with multiple representations of a number 
e.g. 
Class Number{
    public List<string> Lines //4 lines prepresenting an induvidual numnber
    public int? number // the numeric value of the number null for unknown
    public char numberChar // the charecter of the number "?" for unknown
    public BinaryString // a binary representation of the strings i.e. 9 bits representing each position 3 bits per line top down
    
e.g. 

"   "   1   "1" 000001001000

"  |"

"  |"

"   "

this would have helped with converting from and two and using the most appropriate format for each task.
    
    
