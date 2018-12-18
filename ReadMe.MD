#Proposed Solution

There are 2 solutions
1. quick n dirty proof of concept - took about 30 mins to code this is in "QuickNDirtyAlternateSolution Folder" Accessed via Application
2. The "Full Fat" Version - This took ... a bit longer. in all the other folders and also accessed via the application

#Spec Check
Done 1. Parse a file into a list of strings - read the file get a list of lines
Done 2. Parse a list of lines into induvidual "entry" i.e. a group of 4 lines that make up an induvidual account number
Done 3. Split the entry into a list of "DigitalNumbers" where a digital number is 3 lines of 3 chars representing a digital number!!
Done 4. Map the DigitalNumber to ints or ? if illformed
5. Checksum checking
6. Manipulation of invalid numbers

#Terms / Things of Note
model projects have no dependancies (outside of netcore)
interface projects only rely on models
Services DO NO "WORK" - they simply chain together other things
Service tests use mocks but there should be few of them since all they do is chain things

#Assumptions
For The Purposes of this Kata it is assumed that only valid filenames will be provided and that the files are in the correct format And that no Exception handeling is needed or Validation of each line
Outside of the result, logging is not required
No custom exception handleing is required
No NFRs have been provided.
Synchronus opertaion is fine - i.e. no Async is needed.

#Specification
https://code.joejag.com/coding-dojo/bank-ocr/

Coding Dojo: Bank OCR
Bank OCR
Your manager has recently purchased a machine that assists in reading letters and faxes sent in by branch offices. The machine scans the paper documents, and produces a file with a number of entries. You will write a program to parse this file.

Specification
User Story 1
The following format is created by the machine:

    _  _     _  _  _  _  _
  | _| _||_||_ |_   ||_||_|
  ||_  _|  | _||_|  ||_| _|
Each entry is 4 lines long, and each line has 27 characters. The first 3 lines of each entry contain an account number written using pipes and underscores, and the fourth line is blank.

Each account number should have 9 digits, all of which should be in the range 0-9. A normal file contains around 500 entries.

Write a program that can take this file and parse it into actual account numbers.

User Story 2
You find the machine sometimes goes wrong while scanning. You will need to validate that the numbers are valid account numbers using a checksum. This can be calculated as follows:

account number:  3  4  5  8  8  2  8  6  5
position names:  d9 d8 d7 d6 d5 d4 d3 d2 d1

checksum calculation:
((1*d1) + (2*d2) + (3*d3) + ... + (9*d9)) mod 11 == 0
User Story 3
Your boss is keen to see your results. He asks you to write out a file of your findings, one for each input file, in this format:

457508000
664371495 ERR
86110??36 ILL
The output file has one account number per row. If some characters are illegible, they are replaced by a ?. In the case of a wrong checksum, or illegible number, this is noted in a second column indicating status.

User Story 4
It turns out that often when a number comes back as ERR or ILL it is because the scanner has failed to pick up on one pipe or underscore for one of the figures. For example:

    _  _  _  _  _  _     _
|_||_|| || ||_   |  |  ||_
  | _||_||_||_|  |  |  | _|
The 9 could be an 8 if the scanner had missed one |. Or the 0 could be an 8. Or the 1 could be a 7. The 5 could be a 9 or 6. So your next task is to look at numbers that have come back as ERR or ILL, and try to guess what they should be, by adding or removing just one pipe or underscore.

If there is only one possible number with a valid checksum, then use that. If there are several options, the status should be AMB. If you still can't work out what it should be, the status should be reported ILL.

Example input and output
User Story 1
 _  _  _  _  _  _  _  _  _
| || || || || || || || || |
|_||_||_||_||_||_||_||_||_|

=> 000000000

  |  |  |  |  |  |  |  |  |
  |  |  |  |  |  |  |  |  |

=> 111111111

 _  _  _  _  _  _  _  _  _
 _| _| _| _| _| _| _| _| _|
|_ |_ |_ |_ |_ |_ |_ |_ |_ 

=> 222222222

 _  _  _  _  _  _  _  _  _
 _| _| _| _| _| _| _| _| _|
 _| _| _| _| _| _| _| _| _|

=> 333333333

|_||_||_||_||_||_||_||_||_|
  |  |  |  |  |  |  |  |  |

=> 444444444

 _  _  _  _  _  _  _  _  _
|_ |_ |_ |_ |_ |_ |_ |_ |_
 _| _| _| _| _| _| _| _| _|

=> 555555555

 _  _  _  _  _  _  _  _  _
|_ |_ |_ |_ |_ |_ |_ |_ |_
|_||_||_||_||_||_||_||_||_|

=> 666666666

 _  _  _  _  _  _  _  _  _
  |  |  |  |  |  |  |  |  |
  |  |  |  |  |  |  |  |  |

=> 777777777

 _  _  _  _  _  _  _  _  _
|_||_||_||_||_||_||_||_||_|
|_||_||_||_||_||_||_||_||_|

=> 888888888

 _  _  _  _  _  _  _  _  _
|_||_||_||_||_||_||_||_||_|
 _| _| _| _| _| _| _| _| _|

=> 999999999

    _  _     _  _  _  _  _
  | _| _||_||_ |_   ||_||_|
  ||_  _|  | _||_|  ||_| _| 

=> 123456789
User Story 2
Valid:
711111111
123456789
490867715

Invalid:
888888888
490067715
012345678
User Story 3
 _  _  _  _  _  _  _  _
| || || || || || || ||_   |
|_||_||_||_||_||_||_| _|  |

=> 000000051
    _  _  _  _  _  _     _
|_||_|| || ||_   |  |  | _
  | _||_||_||_|  |  |  | _|

=> 49006771? ILL
    _  _     _  _  _  _  _
  | _| _||_| _ |_   ||_||_|
  ||_  _|  | _||_|  ||_| _ 

=> 1234?678? ILL
User Story 4

  |  |  |  |  |  |  |  |  |
  |  |  |  |  |  |  |  |  |

=> 711111111
 _  _  _  _  _  _  _  _  _
  |  |  |  |  |  |  |  |  |
  |  |  |  |  |  |  |  |  |

=> 777777177
 _  _  _  _  _  _  _  _  _
 _|| || || || || || || || |
|_ |_||_||_||_||_||_||_||_|

=> 200800000
 _  _  _  _  _  _  _  _  _
 _| _| _| _| _| _| _| _| _|
 _| _| _| _| _| _| _| _| _|

=> 333393333
 _  _  _  _  _  _  _  _  _
|_||_||_||_||_||_||_||_||_|
|_||_||_||_||_||_||_||_||_|

=> 888888888 AMB ['888886888', '888888880', '888888988']
 _  _  _  _  _  _  _  _  _
|_ |_ |_ |_ |_ |_ |_ |_ |_
 _| _| _| _| _| _| _| _| _|

=> 555555555 AMB ['555655555', '559555555']
 _  _  _  _  _  _  _  _  _
|_ |_ |_ |_ |_ |_ |_ |_ |_
|_||_||_||_||_||_||_||_||_|

=> 666666666 AMB ['666566666', '686666666']
 _  _  _  _  _  _  _  _  _
|_||_||_||_||_||_||_||_||_|
 _| _| _| _| _| _| _| _| _|

=> 999999999 AMB ['899999999', '993999999', '999959999']
    _  _  _  _  _  _     _
|_||_|| || ||_   |  |  ||_
  | _||_||_||_|  |  |  | _|

=> 490067715 AMB ['490067115', '490067719', '490867715']
    _  _     _  _  _  _  _
 _| _| _||_||_ |_   ||_||_|
  ||_  _|  | _||_|  ||_| _| 

=> 123456789
 _     _  _  _  _  _  _
| || || || || || || ||_   |
|_||_||_||_||_||_||_| _|  |

=> 000000051
    _  _  _  _  _  _     _
|_||_|| ||_||_   |  |  | _
  | _||_||_||_|  |  |  | _|

=> 490867715 