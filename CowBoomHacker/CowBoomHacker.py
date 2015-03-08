import urllib2, re, csv;
from BeautifulSoup import BeautifulSoup;


maxPageNubmer = 131;
with open('products.csv', 'wb') as csvFile:
    writer = csv.writer(csvFile, delimiter=",", quotechar='"', quoting=csv.QUOTE_MINIMAL)
    writer.writerow(["Status", "Condition", "Includes", "Doesnt include", "Notes", "PageNumber"])
    while maxPageNubmer > 0:
        url = "http://www.cowboom.com/store/productBestAvailable.cfm?pageno=" + str(maxPageNubmer) + "&contentID=1589774&title=UnBranded%20Windows%208%2010.1in%20Tablet%2032GB%20-%20Gray&ProductTypeID=2&_cf_containerId=results_body&_cf_nodebug=true&_cf_nocache=true&_cf_clientid=9C26D9E2FEA6672577310412E4E213E6&_cf_rc=26"
        cont = urllib2.urlopen(url).read();
        soup = BeautifulSoup(cont)
        descs = soup.findAll('div',{'class':'rtLbl'});
        for eachDesc in descs:
            var1 = str(re.sub("[^a-zA-Z\.\ _-]","", str(eachDesc.contents[2])).replace("nbsp", ""))
            var2 = str(re.sub("[^a-zA-Z\.\ _-]","", str(eachDesc.contents[6])).replace("nbsp", ""))
            var3 = str(re.sub("[^a-zA-Z\.\ _-]","", str(eachDesc.contents[15])).replace("nbsp", ""))
            var4 = str(re.sub("[^a-zA-Z\.\ _-]","", str(eachDesc.contents[20])).replace("nbsp", ""))
            var5 = str(re.sub("[^a-zA-Z\.\ _-]","", str(eachDesc.contents[25])).replace("nbsp", ""))
            var6 = "";
            #try:
            #    eachDesc.contents[33]
            #except
            #var6 = str(re.sub("[^a-zA-Z\.\ _-]","", str(eachDesc.contents[33])).replace("nbsp", ""))
            results = [var1, var2, var3, var4, var5, maxPageNubmer]
            print str(maxPageNubmer)
            print (results)           
            writer.writerow(results)
        maxPageNubmer = maxPageNubmer - 1;