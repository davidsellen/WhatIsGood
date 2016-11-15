package com.dscode.whatsgood;



import java.text.DateFormat;
import java.util.ArrayList;
import java.util.Date;
import java.util.List;

import android.app.Activity;
import android.app.ProgressDialog;
import android.content.Context;
import android.os.AsyncTask;
import android.os.Bundle;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.Menu;
import android.view.View;
import android.view.View.OnClickListener;
import android.view.ViewGroup;
import android.widget.AdapterView;
import android.widget.AdapterView.OnItemClickListener;
import android.widget.ArrayAdapter;
import android.widget.Filter;
import android.widget.ImageButton;
import android.widget.ListView;
import android.widget.TextView;
import android.widget.Toast;

import com.dscode.whatsgood.facade.EventFacade;
import com.dscode.whatsgood.model.Event;
import com.dscode.whatsgood.model.IEventRepository;


public class MainActivity extends Activity {

	EventListAdapter dataAdapter = null;

	TextView genreFilterTextView;

	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_main);

		this.genreFilterTextView = (TextView) findViewById(R.id.editTextGenreFilter);

		// add a click event handler for the button
		final ImageButton btnSearch = (ImageButton) findViewById(R.id.btnSearchEvent);
		btnSearch.setOnClickListener(new OnClickListener() {

			public void onClick(View v) {

				String genreDescription = genreFilterTextView.getText()
						.toString();

				CallWebServiceTask task = new CallWebServiceTask();
				task.applicationContext = MainActivity.this;
				task.execute(genreDescription);
			}
		});
		// displayListView();
	}
	
	public class CallWebServiceTask extends
			AsyncTask<String, Void, List<Event>> {
		private ProgressDialog dialog;
		protected Context applicationContext;

		@Override
		protected void onPreExecute() {
			this.dialog = ProgressDialog.show(applicationContext,
					"Processando", "Pesquisando eventos...", true);
		}

		@Override
		protected List<Event> doInBackground(String... params) {
			IEventRepository repository = new EventFacade();
			List<Event> eventList = repository.GetByGenre(params[0]);
			return eventList;
		}

		protected void onPostExecute(List<Event> result) {
			this.dialog.cancel();
			displayListView(result);
		}

	}


	private void displayListView(List<Event> eventList) {
		
		dataAdapter = new EventListAdapter(this, R.layout.event_info, eventList);
		
		ListView eventListView = (ListView)findViewById(R.id.eventListView);
		eventListView.setAdapter(dataAdapter);
		eventListView.setTextFilterEnabled(true);
		eventListView.setOnItemClickListener(new OnItemClickListener(){
			@Override
			public void onItemClick(AdapterView<?> parent, View view, int position, long id) {
				Event event = (Event)parent.getItemAtPosition(position);
				Toast.makeText(getApplicationContext(), event.getArtistName(), Toast.LENGTH_SHORT).show();
			}		
		});
	}

	@Override
	public boolean onCreateOptionsMenu(Menu menu) {
		// Inflate the menu; this adds items to the action bar if it is present.
		getMenuInflater().inflate(R.menu.main, menu);
		return true;
	}
	
	private class EventListAdapter extends ArrayAdapter<Event> {

		private ArrayList<Event> originalList;
		private ArrayList<Event> eventList;
		private EventFilter filter;
		  
		public EventListAdapter(Context context, int resourceId, List<Event> eventList) {
			super(context, resourceId, eventList);
			
			this.originalList= new ArrayList<Event>();
			this.originalList.addAll(eventList);
			this.eventList= new ArrayList<Event>();
			this.eventList.addAll(eventList);			
		}
		
		@Override
		public Filter getFilter() {
		   if (filter == null){
			   filter  = new EventFilter();
		   }
		   return filter;
		}
		
		private class EventFilter extends Filter {

		   @Override
		   protected FilterResults performFiltering(CharSequence constraint) {
		    constraint = constraint.toString().toLowerCase();
		    FilterResults result = new FilterResults();
		    if(constraint != null && constraint.toString().length() > 0) {
		    	ArrayList<Event> filteredItems = new ArrayList<Event>();
		    	for(int i = 0, l = originalList.size(); i < l; i++) {
		    		Event event = originalList.get(i);
		    		if(event.toString().toLowerCase().contains(constraint))
		    			filteredItems.add(event);
		    	}
		    	result.count = filteredItems.size();
		    	result.values = filteredItems;
		    }
		    else {
		    	synchronized(this)
		    	{
		    		result.values = originalList;
		    		result.count = originalList.size();
		    	}
		    }
		    return result;
		   }

		   @SuppressWarnings("unchecked")
		   @Override
		   protected void publishResults(CharSequence constraint, FilterResults results) {
			   eventList = (ArrayList<Event>)results.values;
			   notifyDataSetChanged();
			   clear();
			   for(int i = 0, l = eventList.size(); i < l; i++)
				   add(eventList.get(i));
			   notifyDataSetInvalidated();
		   }
		 }

		
		private class ViewHolder {
			   TextView name;
			   TextView genre;
			   TextView location;
			   TextView price;
			TextView startDate;
			TextView address;
		}

		@Override
		public View getView(int position, View convertView, ViewGroup parent) {

		   ViewHolder holder = null;
		   Log.v("ConvertView", String.valueOf(position));
		   if (convertView == null) {
			   LayoutInflater vi = (LayoutInflater)getSystemService(Context.LAYOUT_INFLATER_SERVICE);		   
			   convertView = vi.inflate(R.layout.event_info, null);
			   holder = new ViewHolder();
			   holder.location = (TextView) convertView.findViewById(R.id.textViewEventLocation);
			   holder.name = (TextView) convertView.findViewById(R.id.textViewEventName);
			   holder.genre = (TextView) convertView.findViewById(R.id.textViewEventGenre);
			   holder.price = (TextView) convertView.findViewById(R.id.textViewEventPrice);
				holder.address = (TextView) convertView
						.findViewById(R.id.textViewAddress);
				holder.startDate = (TextView) convertView
						.findViewById(R.id.textViewEventStartDate);
			   convertView.setTag(holder);
		   } else {
			   holder = (ViewHolder) convertView.getTag();
		   }

		   Event event = eventList.get(position);
		   holder.name.setText(event.getName());
		   holder.location.setText(event.getLocation());
		   holder.price.setText(event.getPriceRange());
		   holder.genre.setText(event.getGenreDescription());
			holder.address.setText(event.getEventAddress());
			holder.startDate.setText(getLongDateString(event.getStartDate()));

		   return convertView;

		}

		private String getLongDateString(Date date) {
			if (date == null)
				return "";
			return DateFormat.getDateTimeInstance().format(date);
		}
	}

}
